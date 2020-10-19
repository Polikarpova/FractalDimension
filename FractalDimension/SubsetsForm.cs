using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace FractalDimension
{
    public partial class SubsetsForm : Form
    {
        public SubsetsForm(string imagesPath)
        {
            InitializeComponent();

            var files = Directory.EnumerateFiles(imagesPath);
            foreach (string file in files)
            {
                PictureBox picture = new PictureBox
                {
                    BackgroundImage = Image.FromFile(file),
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Size = new Size(200, 200)
                };

                FlowLayoutPanel.Controls.Add(picture);
            }
        }

        private void SubsetsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //получить все картинки и освободить их
            foreach (PictureBox control in FlowLayoutPanel.Controls)
            {
                control.BackgroundImage.Dispose();
            }
        }
    }
}
