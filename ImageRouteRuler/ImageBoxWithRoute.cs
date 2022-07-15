using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ImageRouteRuler
{
    public class ImageBoxWithRoute : Cyotek.Windows.Forms.ImageBox
    {
        private readonly Pen _pen = new Pen(Color.OrangeRed, 5);
        private readonly Font _font = new Font("Arial", 30);
        private readonly SolidBrush _brush = new SolidBrush(Color.OrangeRed);

        private readonly Font _fontSmall = new Font("Arial", 12, FontStyle.Bold);
        private readonly SolidBrush _brushSmall = new SolidBrush(Color.OrangeRed);

        public void DrawRoute(Graphics graphics, Route route, Settings settings)
        {
            DrawPoints(graphics, route, settings);
            DrawLines(graphics, route);
            DrawDistance(graphics, route);
        }

        private void DrawPoints(Graphics graphics, Route points, Settings settings)
        {
            foreach (var point in points.Points())
            {
                var scaled = this.GetOffsetPoint(point.Point);
                graphics.DrawEllipse(_pen, scaled.X - 2, scaled.Y - 2, 5, 5);

                if (settings.DrawLabels)
                {
                    graphics.DrawString(point.DistanceFromLast.ToString("0.000"), _fontSmall, _brushSmall, scaled.X + 20, scaled.Y + 10);
                    graphics.DrawString(point.DistanceFromBeginning.ToString("0.000"), _fontSmall, _brushSmall, scaled.X + 20, scaled.Y + 22);
                }

            }
        }

        private void DrawLines(Graphics graphics, Route route)
        {
            if (route.Count > 1)
            {
                var path = new GraphicsPath();
                path.AddLines(route.Points().Select(x => this.GetOffsetPoint(x.Point)).ToArray());
                graphics.DrawPath(_pen, path);
            }
        }

        private void DrawDistance(Graphics graphics, Route route)
        {
            graphics.DrawString(route.WholeDistance.ToString("0.000") + " km", _font, _brush, 0, 0);
        }
    }
}
