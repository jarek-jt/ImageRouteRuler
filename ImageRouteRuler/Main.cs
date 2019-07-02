using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageRouteRuler
{
    public partial class Main : Form
    {
        private Point _mouseDown = new Point();
        private Settings settings;
        private Route route;

        public Main()
        {
            InitializeComponent();

            settings = new Settings();
            settings.Dpi = imageBox1?.Image?.HorizontalResolution ?? 0;

            route = new Route(settings);

        }

        private void ImageBox1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            imageBox1.DrawRoute(e.Graphics, route);
        }

        private void BReset_Click(object sender, EventArgs e)
        {
            route.DeleteAll();
            imageBox1.Invalidate();
        }

        private void ImageBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left && e.Location==_mouseDown)
            {
                route.AddPoint(imageBox1.PointToImage(e.Location));
                imageBox1.Invalidate();
            }
        }

        private void ImageBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = e.Location;
        }

        private void BDelLast_Click(object sender, EventArgs e)
        {
                route.DeleteLast();
                imageBox1.Invalidate();
        }

        private void BLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.tiff, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff; *.bmp";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    imageBox1.Image = Image.FromFile(openFile.FileName);
                    SetSettings(openFile);
                }
            }
        }

        private void TextScale_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(textScale.Text, out double scale))
            {
                if (scale > 0 && scale < 100000)
                {
                    settings.Scale = scale;
                    route.Recalculate();
                    imageBox1.Invalidate();
                }
            }

        }

        private void SetSettings(OpenFileDialog openFile)
        {
            settings.File = openFile.FileName;
            settings.Dpi = imageBox1.Image.HorizontalResolution;
        }
    }
}
