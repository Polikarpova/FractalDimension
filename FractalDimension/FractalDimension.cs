using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace FractalDimension
{
    class FractalDimension
    {
        public int BlackBoundary = 100;
        public int DeltaMax = 4;
        public int QMin = 1;
        public int QMax = 10;
        public double MFEpsilon = 1E-6;
        public double AlphaMin, AlphaMax;
        
        public List<Tuple<double, double>> CDPoints { get; private set; }
        public List<Tuple<double, double>> MDPoints { get; private set; }
        public List<Tuple<double, double>> SRPoints { get; private set; }
        public List<Tuple<Tuple<double, double>, double>> MFPoints { get; private set; }

        public string LocalDensityImagesDirectory { get; private set; }

        private Bitmap image;
        private delegate float Predicat(float val1, float val2);
        private readonly string LocalDensityImages = "LocalDensityImages";
        private double totalSaturationSum;

        public List<Tuple<double, double>> AlphaGroups { get; private set; }

        //----------------------Емкостная размерность для черно-белых изображений----------------------//
        public double CalculateCapacitiveDimension(string imagepath)
        {
            image = new Bitmap(imagepath);

            double result = CalculateCapacitiveDimension();

            image.Dispose();

            return result;
        }

        private double CalculateCapacitiveDimension()
        {
            double result = 0d;
            
            CDPoints = new List<Tuple<double, double>>();

            int epsilon = Math.Min(image.Width, image.Height) / 2;

            while (epsilon > 1)
            {
                CDPoints.Add(GetPoint(epsilon));
                epsilon /= 2;
            }

            result = GetAproximationByLessSquareMethod(CDPoints);

            return result;
        }

        private Tuple<double, double> GetPoint(int epsilon)
        {
            double NEpsilon = 0f;

            //считаем NEpsilon
            for (int x = 0; x <= image.Width; x += epsilon)
            {
                //Если нельзя больше выделить ячейку по ширине
                if (image.Width - x < epsilon)
                    continue;

                int x1 = x + epsilon;

                for (int y = 0; y <= image.Height; y += epsilon)
                {
                    //Если нельзя больше выделить ячейку по ширине
                    if (image.Height - y < epsilon)
                        continue;

                    int y1 = y + epsilon;

                    //для ячейки ищем пиксель и если он есть, то прибавляем
                    NEpsilon += IsFractalInCell(x, x1, y, y1) ? 1 : 0;
                }
            }

            return new Tuple<double, double>(Math.Log(1d / epsilon), Math.Log(NEpsilon));
        }

        /* В ячейке размерами [xStart; xEnd) по ширине и [yStart; yEnd) ищем черный пиксель
         * Пиксели в точке (xEnd; yEnd) не проверяются!
         */
        private bool IsFractalInCell(int xStart, int xEnd, int yStart, int yEnd)
        {
            for (int x = xStart; x < xEnd; x++)
            {
                for (int y = yStart; y < yEnd; y++)
                {
                    if (IsBlackPixel(image.GetPixel(x, y)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsBlackPixel(Color pixel)
        {
            if (pixel.R <= BlackBoundary && pixel.G <= BlackBoundary && pixel.B <= BlackBoundary)
            {
                return true;
            }

            return false;
        }

        private double GetAproximationByLessSquareMethod(List<Tuple<double, double>> points)
        {
            LessSquare.GetCoefficient(points, out double k, out double b);

            return k;
        }

        //----------------------Размерность Минковского для полутоновых изображений----------------------//

        /* Рассчет с известной epsilon */
        public float CalculateMinkowskiDimensionForGrayscaleImages(string imagepath, int epsilon)
        {
            image = new Bitmap(imagepath);

            float result = GetMinkowskiDimensionForGrayscaleImages(epsilon);

            image.Dispose();

            return result;
        }

        /* Рассчет с зависимостью размерности от количества ячеек разбиения */
        public void CalculateMinkowskiDimensionForGrayscaleImages(string imagepath)
        {
            image = new Bitmap(imagepath);
            MDPoints = new List<Tuple<double, double>>();

            int epsilon = Math.Min(image.Width, image.Height);

            while (epsilon > 1)
            {
                MDPoints.Add(new Tuple<double, double>(epsilon, GetMinkowskiDimensionForGrayscaleImages(epsilon)));
                epsilon /= 2;
            }
        }

        private float GetMinkowskiDimensionForGrayscaleImages(int epsilon)
        {
            float result = 0;

            //Делим изображение на ячейки и для каждой считаем A delta
            List<float> ADeltas = GetADeltas(epsilon);

            //Складываем полученные A delta
            foreach (float ADelta in ADeltas)
            {
                result += ADelta;
            }

            return result;
        }

        private List<float> GetADeltas(int epsilon)
        {
            List<float> ADeltas = new List<float>();

            for (int x = 0; x <= image.Width; x += epsilon)
            {
                //Если нельзя больше выделить ячейку по ширине
                if (image.Width - x < epsilon)
                    continue;

                int x1 = x + epsilon;

                for (int y = 0; y <= image.Height; y += epsilon)
                {
                    //Если нельзя больше выделить ячейку по ширине
                    if (image.Height - y < epsilon)
                        continue;

                    int y1 = y + epsilon;

                    //для каждой ячейки
                    ADeltas.Add(ComputeADeltaWithApproximation(x, x1 - 1, y, y1 - 1, DeltaMax));
                }
            }

            return ADeltas;
        }

        /* Площадь вычисляется по следующей формуле:
         * 
         *           V delta - V delta-1
         * A delta = -------------------- , где delta задается при помощи deltaMax
         *                    2
         */
        private float ComputeADeltaWithApproximation(int xStart, int xEnd, int yStart, int yEnd, int deltaMax)
        {
            float result = 0;

            int rowsCount = xEnd - xStart + 1;
            int colsCount = yEnd - yStart + 1;

            List<float> VDeltas = new List<float>();

            //предыдущие верхнее и нижнее одеяло, но на первом шаге они равны между собой и 
            //равны карте градации серого изображения
            float[,] UDeltaMinus1 = GetGrayscaleMatrix(rowsCount, colsCount);
            float[,] BDeltaMinus1 = GetGrayscaleMatrix(rowsCount, colsCount);

            //Высчитываем объёмы покрывал
            for (int delta = 1; delta <= deltaMax; delta++)
            {
                //строим верхнее и нижнее покрывало, т.е. матрицы
                float[,] UDelta = CreateBlanket(rowsCount, colsCount, ref UDeltaMinus1, true);
                float[,] BDelta = CreateBlanket(rowsCount, colsCount, ref BDeltaMinus1, false);

                //получаем Vol delta суммируя разницу каждого u(i,j)-b(i,j) и добавляем его в список
                VDeltas.Add(CalculateVDelta(rowsCount, colsCount, ref UDelta, ref BDelta));

                //заменяем предыдущие на новые
                UDeltaMinus1 = UDelta;
                BDeltaMinus1 = BDelta;
            }

            result = (VDeltas[deltaMax - 1] - VDeltas[deltaMax - 2]) / 2f;

            return result;
        }

        private float[,] GetGrayscaleMatrix(int rowsCount, int colsCount)
        {
            float[,] result = new float[rowsCount, colsCount];

            for (int x = 0; x < rowsCount; x++)
            {
                for (int y = 0; y < colsCount; y++)
                {
                    result[x, y] = image.GetPixel(x, y).GetSaturation();
                }
            }

            return result;
        }

        private float[,] CreateBlanket(int rowsCount, int colsCount, ref float[,] previousBlanket, bool isUpper)
        {
            float[,] result = new float[rowsCount, colsCount];
            float c = isUpper ? .01f : -.01f;

            for (int x = 0; x < rowsCount; x++)
            {
                for (int y = 0; y < colsCount; y++)
                {
                    float element = previousBlanket[x, y] + c;

                    //по всем соседям
                    for (int i = -1; i <= 1; i++)
                    {
                        //если вышли за рамки массива по строке, то пропускаем
                        if (x + i < 0 || x + i >= rowsCount)
                            continue;

                        for (int j = -1; j <= 1; j++)
                        {
                            //если вышли за рамки массива по столбцу, то пропускаем
                            if (y + j < 0 || y + j >= colsCount)
                                continue;
                            
                            //если это сам элемент, то пропускаем
                            if (i == 0 && j == 0)
                                continue;

                            float neighbourElement = previousBlanket[x + i, y + j];

                            //если соседний элемент выполняет условие, то заменяем e на него
                            element = result[x, y] = GetPredicat(isUpper)(element, neighbourElement);
                        }
                    }
                }
            }

            return result;
        }

        private Predicat GetPredicat(bool isMax)
        {
            if (isMax)
            {
                return Math.Max;
            }

            return Math.Min;
        }

        private float CalculateVDelta(int rowsCount, int colsCount, ref float[,] UDelta, ref float[,] BDelta)
        {
            float result = 0;

            for (int x = 0; x < rowsCount; x++)
            {
                for (int y = 0; y < colsCount; y++)
                {
                    result += UDelta[x, y] - BDelta[x, y];
                }
            }

            return result;
        }

        //----------------------Спектр Реньи для полутоновых изображений----------------------//

        public void CalculateRenyiSpectre(string imagepath)
        {
            SRPoints = new List<Tuple<double, double>>();
            
            for (int q = QMin; q <= QMax; q++)
            {
                image = new Bitmap(imagepath);

                if (q == 0)
                {
                    //емкостная
                    BlackBoundary = 230;
                    SRPoints.Add(new Tuple<double, double>(q, CalculateCapacitiveDimension()));
                    BlackBoundary = 100;
                }
                else if (q == 1)
                {
                    //информационная
                    SRPoints.Add(new Tuple<double, double>(q, CalculateEntropy()));
                }
                else
                {
                    SRPoints.Add(new Tuple<double, double>(q, GetRenyiSpectre(q)));
                }

                image.Dispose();
            }
        }

        private double GetRenyiSpectre(int q)
        {
            List<Tuple<double, double>> points = new List<Tuple<double, double>>();
            int epsilon = Math.Min(image.Width, image.Height) /2;
            int qMinus1 = (q - 1) == 0 ? 1 : (q - 1);

            while (epsilon > 1)
            {
                points.Add(new Tuple<double, double>(Math.Log(epsilon) * qMinus1, Math.Log(GetSumOfStandardizedMeasures(q, epsilon))));

                epsilon /= 2;
            }
                        
            double result = GetAproximationByLessSquareMethod(points);

            return result;
        }

        private double GetSumOfStandardizedMeasures(int q, int epsilon)
        {
            double result = 0d;

            GetSaturatutionSumList(epsilon, out List<Double> saturationSumInCells);

            double saturationSums = GetSum(ref saturationSumInCells);

            foreach (double sum in saturationSumInCells)
            {
                double pi = sum / saturationSums;
                result += Math.Pow( pi, (double)q);
            }

            return result;
        }

        private void GetSaturatutionSumList(int epsilon, out List<Double> saturationSumInCells)
        {
            saturationSumInCells = new List<double>();

            for (int x = 0; x <= image.Width; x += epsilon)
            {
                //Если нельзя больше выделить ячейку по ширине
                if (image.Width - x < epsilon)
                    continue;

                int x1 = x + epsilon;

                for (int y = 0; y <= image.Height; y += epsilon)
                {
                    //Если нельзя больше выделить ячейку по ширине
                    if (image.Height - y < epsilon)
                        continue;

                    int y1 = y + epsilon;

                    //для каждой ячейки
                    saturationSumInCells.Add(GetSaturationSumInCell(x, x1, y, y1));
                }
            }
        }

        private double GetSaturationSumInCell(int xStart, int xEnd, int yStart, int yEnd)
        {
            double result = 0d;

            for (int x = xStart; x < xEnd; x++)
            {
                for (int y = yStart; y < yEnd; y++)
                {
                    result += image.GetPixel(x, y).GetSaturation();
                }
            }

            return result;
        }

        private double GetSum(ref List<double> saturationSumInCell)
        {
            double result = 0d;

            foreach (double sum in saturationSumInCell)
            {
                result += sum;
            }

            return result;
        }

        //----------------------Мультифрактальный спектр для полутоновых----------------------//
        //--------------------с использованием локальной функции плотности--------------------//

        public void PrecalculateAlpaMinAlpaMax(string imagepath)
        {
            image = new Bitmap(imagepath);

            //заранее высчитываем полную сумму насыщенности всех пикселей картинки
            totalSaturationSum = GetSaturationSumInCell(0, image.Width, 0, image.Height);

            CalculateAlphaMinAlphaMax(out AlphaMin, out AlphaMax);
        }

        public void CalculateMultufractalWithLocalDensityFunction()
        {
            PrepareFolderForImages();

            CalculateMultifractalDimension();

            image.Dispose();
        }

        private void PrepareFolderForImages()
        {
            //нужна пустая папочка LocalDensityImages
            LocalDensityImagesDirectory = Path.Combine(Environment.CurrentDirectory, LocalDensityImages);

            if (!Directory.Exists(LocalDensityImagesDirectory))
            {
                Directory.CreateDirectory(LocalDensityImagesDirectory);
            }

            var files = Directory.EnumerateFiles(LocalDensityImagesDirectory);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        private void CalculateMultifractalDimension()
        {
            CalculateAlphaGroups();

            MFPoints = new List<Tuple<Tuple<double, double>, double>>();
            int index = 0;
            var files = Directory.EnumerateFiles(LocalDensityImagesDirectory);
            foreach (string file in files)
            {
                //считаем емкостную размерность
                double CD = CalculateCapacitiveDimension(file);

                MFPoints.Add(new Tuple<Tuple<double, double>, double>(AlphaGroups[index], CD));

                index++;
            }
        }

        private void CalculateAlphaGroups()
        {
            AlphaGroups = new List<Tuple<double, double>>();

            int imageIndex = 1;
            for (double alpha = AlphaMin; AlphaMax - alpha >= 1.0E-6; alpha += MFEpsilon, imageIndex++)
            {
                Bitmap layerImage = new Bitmap(image.Width, image.Height);

                //по всем точкам исходной картинки
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        double currentAlpha = CalculateAlpha(x, y);

                        if (currentAlpha >= alpha && currentAlpha < alpha + MFEpsilon)
                        {
                            layerImage.SetPixel(x, y, Color.Black);
                        }
                        else
                        {
                            layerImage.SetPixel(x, y, Color.White);
                        }
                    }
                }

                //картинку сохраняем в именную папочку под номером
                string filename = Path.Combine(LocalDensityImagesDirectory, imageIndex.ToString() + ".bmp");
                layerImage.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp);

                //сохраняем AlphaPoints значения [alpha; alpha+eps), а второй double пока назначаем 0d
                AlphaGroups.Add(new Tuple<double, double>(alpha, alpha + MFEpsilon > AlphaMax ? AlphaMax : alpha + MFEpsilon));
            }
        }

        private void CalculateAlphaMinAlphaMax(out double alphaMin, out double alphaMax)
        {
            SortedSet<double> result = new SortedSet<double>();

            //для каждой точки посчитать насыщенность / сумму насыщенностей  => получаем список d(x)
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    result.Add(CalculateAlpha(x, y));
                }
            }

            alphaMin = result.Min;
            alphaMax = result.Max;
        }

        private double CalculateAlpha(int x, int y)
        {
            return image.GetPixel(x, y).GetSaturation() / totalSaturationSum;
        }

        //----------------------Информационная размерность----------------------//

        private double CalculateEntropy()
        {
            List<Tuple<double, double>> points = new List<Tuple<double, double>>();
            int epsilon = Math.Min(image.Width, image.Height) / 2;

            while (epsilon > 1)
            {
                double sumP = GetSumOfStandardizedMeasuresForEntropy(epsilon);
                points.Add(new Tuple<double, double>(Math.Log(epsilon), sumP));

                epsilon /= 2;
            }

            double result = GetAproximationByLessSquareMethod(points);

            return result;
        }

        private double GetSumOfStandardizedMeasuresForEntropy(int epsilon)
        {
            double result = 0d;

            GetSaturatutionSumList(epsilon, out List<Double> saturationSumInCell);

            double saturationSums = GetSum(ref saturationSumInCell);

            foreach (double sum in saturationSumInCell)
            {
                double pi = sum / saturationSums;
                result += pi * Math.Log(pi);
            }

            return result;
        }
    }
}
