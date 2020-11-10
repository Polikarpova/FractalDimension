using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace FractalDimension
{
    public partial class GraphForm : Form
    {
        private GraphPane gp;

        public GraphForm()
        {
            InitializeComponent();

            gp = Graph.GraphPane;
        }

        public void DrawApproximation(IList<Tuple<double, double>> points)
        {
            gp.Title.Text = "График аппроксимации";
            gp.YAxis.Title.Text = "N(eps)";
            gp.XAxis.Title.Text = "eps";

            gp.CurveList.Clear();

            //Рисуем точки
            PointPairList list = new PointPairList();

            foreach (Tuple<double, double> point in points)
            {
                list.Add(point.Item1, point.Item2);
            }

            LineItem scatterLine = gp.AddCurve("", list, Color.DarkBlue, SymbolType.Triangle);
            scatterLine.Line.IsVisible = false;
            scatterLine.Symbol.Fill.Color = Color.DarkBlue;
            scatterLine.Symbol.Fill.Type = FillType.Brush;

            //Рисуем апроксимацию

            LessSquare.GetCoefficient(points, out double k, out double b);

            PointPairList fList = new PointPairList();

            double xMin = ((int)points[0].Item1) - 1;
            double xMax = ((int)points[points.Count - 1].Item1) + 1;
            double yMin = ((int)points[0].Item2) - 1;
            double yMax = ((int)points[points.Count - 1].Item2) + 1;

            for (double x = xMin; x < xMax; x++)
            {
                fList.Add(x, LinearFunction(x, k, b));
            }

            LineItem line = gp.AddCurve("", fList, Color.Red, SymbolType.None);

            gp.XAxis.Scale.Min = xMin;
            gp.XAxis.Scale.Max = xMax;
            gp.YAxis.Scale.Min = yMin;
            gp.YAxis.Scale.Max = yMax;

            Graph.AxisChange();
            Graph.Invalidate();
        }

        public void DrawRelation(IList<Tuple<double, double>> points, string title, string yAxisTitle, string xAxisTitle)
        {
            gp.Title.Text = title;
            gp.YAxis.Title.Text = yAxisTitle;
            gp.XAxis.Title.Text = xAxisTitle;

            gp.CurveList.Clear();

            //Рисуем точки
            PointPairList list = new PointPairList();

            foreach (Tuple<double, double> point in points)
            {
                list.Add(point.Item1, point.Item2);
            }

            LineItem scatterLine = gp.AddCurve("", list, Color.DarkBlue, SymbolType.Triangle);
            scatterLine.Symbol.Fill.Color = Color.DarkBlue;
            scatterLine.Symbol.Fill.Type = FillType.Brush;

            Graph.AxisChange();
            Graph.Invalidate();
        }

        public void DrawLayers(IList<Tuple<Tuple<double, double>, double>> points, string title, string yAxisTitle, string xAxisTitle)
        {
            gp.Title.Text = title;
            gp.YAxis.Title.Text = yAxisTitle;
            gp.XAxis.Title.Text = xAxisTitle;

            gp.CurveList.Clear();
            
            PointPairList list = new PointPairList();
            string[] names = new string[points.Count];

            int i = 0;
            foreach (Tuple<Tuple<double, double>, double> point in points)
            {
                list.Add(point.Item1.Item1, point.Item2);

                names[i] = String.Format("от {0} до {1} ", Math.Round(point.Item1.Item1 * 1E+5, 3), Math.Round(point.Item1.Item2 * 1E+5, 3));
                i++;
            }

            BarItem curve = gp.AddBar("", list, Color.Blue);

            gp.BarSettings.MinClusterGap = 5;
            gp.XAxis.Type = AxisType.Text;
            gp.XAxis.Scale.TextLabels = names;
            gp.XAxis.Scale.FontSpec.Size = 10;

            Graph.AxisChange();
            Graph.Invalidate();
        }

        private double LinearFunction (double x, double k, double b)
        {
            return k * x + b;
        }
    }
}
