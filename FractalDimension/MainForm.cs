using System;
using System.Drawing;
using System.Windows.Forms;

namespace FractalDimension
{
    public partial class MainForm : Form
    {
        private string imageFilepath;
        private FractalDimension fdc;

        public MainForm()
        {
            InitializeComponent();

            fdc = new FractalDimension();

            imageFilepath = string.Empty;
            BlackBoundaryInput.Value = fdc.BlackBoundary;

            SetEnablePanels(false);
        }

        private void SetEnablePanels(bool isEnable)
        {
            CDPanel.Enabled = MDPanel.Enabled = SRPanel.Enabled = MFPanel.Enabled = isEnable;
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
                
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    imageFilepath = openFileDialog.FileName;
                    ImageBox.BackgroundImage = Image.FromFile(imageFilepath);

                    CellSizeInput.Enabled = true;
                    CellSizeInput.Maximum = Math.Min(ImageBox.BackgroundImage.Width, ImageBox.BackgroundImage.Height) / 16;
                    SetEnablePanels(true);
                }
            }
        }

        private void BCCalculateButton_Click(object sender, EventArgs e)
        {
            fdc.BlackBoundary = (int) BlackBoundaryInput.Value;
            BCAnswerText.Text = fdc.CalculateCapacitiveDimension(imageFilepath).ToString();

            GraphForm graphForm = new GraphForm();
            graphForm.DrawApproximation(fdc.CDPoints);
            graphForm.Show();
        }

        private void SetBlackBoundaryButton_Click(object sender, EventArgs e)
        {
            SetBlackBoundaryToImageBox();
        }

        private void SetBlackBoundaryToImageBox()
        {
            int blackBoundary = (int) BlackBoundaryInput.Value;
            Bitmap image = new Bitmap(Image.FromFile(imageFilepath));
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);

                    if (pixel.R <= blackBoundary && pixel.G <= blackBoundary && pixel.B <= blackBoundary)
                    {
                        newImage.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        newImage.SetPixel(x, y, Color.White);
                    }
                }
            }

            ImageBox.BackgroundImage = newImage;
        }

        private void MDCalculateButton_Click(object sender, EventArgs e)
        {
            int epsilon = (int) CellSizeInput.Value;

            MDAnswerText.Text = fdc.CalculateMinkowskiDimensionForGrayscaleImages(imageFilepath, epsilon).ToString();
        }

        private void MDRelaionButton_Click(object sender, EventArgs e)
        {
            int epsilon = (int)CellSizeInput.Value;

            fdc.CalculateMinkowskiDimensionForGrayscaleImages(imageFilepath);

            GraphForm graphForm = new GraphForm();
            graphForm.DrawRelation(fdc.MDPoints, "График зависимости A delta от размера ячейки разбиения", "A delta", "eps");
            graphForm.Show();
        }

        private void QMinInput_ValueChanged(object sender, EventArgs e)
        {
            QMaxInput.Minimum = QMinInput.Value + 1;
        }

        private void QMaxInput_ValueChanged(object sender, EventArgs e)
        {
            QMinInput.Maximum = QMaxInput.Value - 1;
        }

        private void SRCalculateButton_Click(object sender, EventArgs e)
        {
            fdc.QMin = (int) QMinInput.Value;
            fdc.QMax = (int) QMaxInput.Value;

            fdc.CalculateRenyiSpectre(imageFilepath);

            GraphForm graphForm = new GraphForm();
            graphForm.DrawRelation(fdc.SRPoints, "График зависимости D(q) от значения q", "D(q)", "q");
            graphForm.Show();
        }
        
        private void MFPrecalculateButton_Click(object sender, EventArgs e)
        {
            fdc.PrecalculateAlpaMinAlpaMax(imageFilepath);

            alphaMinText.Text = String.Format("{0} * E-5", Math.Round(fdc.AlphaMin * 1E+5, 3));
            alphaMaxText.Text = String.Format("{0} * E-5", Math.Round(fdc.AlphaMax * 1E+5, 3));

            EpsilonInput.Enabled = MFCalculateButton.Enabled = true;
        }

        private void MFCalculateButton_Click(object sender, EventArgs e)
        {
            fdc.MFEpsilon = (double) EpsilonInput.Value;

            fdc.CalculateMultufractalWithLocalDensityFunction();

            //рисуем график
            GraphForm graphForm = new GraphForm();
            graphForm.DrawLayers(fdc.MFPoints, "Гистограмма спектров", "Емкостная размерность", "Диапазоны alpha (*E-5)");
            graphForm.Show();

            //получаем сформированные картинки
            SubsetsForm subsetsForm = new SubsetsForm(fdc.LocalDensityImagesDirectory, fdc.AlphaGroups);
            subsetsForm.Show();
        }
    }
}
