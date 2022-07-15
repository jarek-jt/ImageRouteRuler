using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageRouteRuler
{
    public partial class Main : Form
    {
        private Point _mouseDown = new Point();
        private Settings _settings;
        private readonly Route _route;

        public Main()
        {
            InitializeComponent();

            UpdateSettings();

            _route = new Route(_settings);

        }

        private void ImageBox1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            imageBox1.DrawRoute(e.Graphics, _route, _settings);
        }

        private void BReset_Click(object sender, EventArgs e)
        {
            _route.DeleteAll();
            imageBox1.Invalidate();
        }

        private void ImageBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Location == _mouseDown)
            {
                _route.AddPoint(imageBox1.PointToImage(e.Location));
                imageBox1.Invalidate();
            }
        }

        private void ImageBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = e.Location;
        }

        private void BDelLast_Click(object sender, EventArgs e)
        {
            _route.DeleteLast();
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

                    _settings.File = openFile.FileName;
                    _route.DeleteAll();

                    UpdateSettings();

                    imageBox1.Invalidate();
                }
            }
        }

        private void TextScale_TextChanged(object sender, EventArgs e)
        {
            UpdateSettings();
            _route.Recalculate();
            imageBox1.Invalidate();
        }

        private void CheckLabels_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSettings();
            imageBox1.Invalidate();
        }

        private void UpdateSettings()
        {
            if (_settings == null)
                _settings = new Settings();

            if (Double.TryParse(textScale.Text, out double scale))
            {
                if (scale > 0 && scale < 100000)
                    _settings.Scale = scale;
            }

            _settings.Dpi = imageBox1.Image?.HorizontalResolution ?? 0;
            _settings.DrawLabels = checkLabels.Checked;
        }

        private void BSaveTrack_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.DefaultExt = "json files (*.json)|*.json";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Serializer.Save<PointInfo>(dialog.FileName, _route.Points());
                }
            }
        }

        private void BLoadRoute_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Json files (*.json) | *.json";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    var loaded = Serializer.Load<PointInfo>(openFile.FileName);

                    _route.DeleteAll();
                    _route.AddRange(loaded.Select(x => x.Point));

                    imageBox1.Invalidate();
                }
            }
        }
    }
}
