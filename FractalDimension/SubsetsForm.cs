using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FractalDimension
{
    public partial class SubsetsForm : Form
    {

        private int imageSize = 200;

        public SubsetsForm(string imagesPath, List<Tuple<double, double>> alphaGroups)
        {
            InitializeComponent();

            var files = Directory.EnumerateFiles(imagesPath);
            int i = 0;
            foreach (string file in files)
            {
                PictureBox picture = new PictureBox
                {
                    BackgroundImage = Image.FromFile(file),
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Size = new Size(imageSize, imageSize),
                    Dock = DockStyle.Top
                };

                Label titleLabel = new Label
                {
                    Text = String.Format("от {0} до {1} ", Math.Round(alphaGroups[i].Item1 * 1E+5, 3), Math.Round(alphaGroups[i].Item2 * 1E+5, 3)),
                    TextAlign =  ContentAlignment.MiddleCenter,
                    Location = new Point(10, 10),
                    Dock = DockStyle.Bottom
                };

                Panel panel = new Panel
                {
                    Size = new Size(imageSize, imageSize + 30)
                };

                panel.Controls.Add(picture);
                panel.Controls.Add(titleLabel);

                FlowLayoutPanel.Controls.Add(panel);

                i++;
            }
        }

        private void SubsetsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //получить все картинки и освободить их
            foreach (Panel panels in FlowLayoutPanel.Controls)
            {
                foreach (Control form in panels.Controls)
                {
                    if (form.GetType().Name == "PictureBox")
                    {
                        form.BackgroundImage.Dispose();
                    }
                }
            }
        }
    }
}
