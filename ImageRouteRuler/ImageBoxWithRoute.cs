using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ImageRouteRuler
{
    public class ImageBoxWithRoute : Cyotek.Windows.Forms.ImageBox
    {
        private Pen _pen = new Pen(Color.OrangeRed, 5);
        private Font _font = new Font("Arial", 30);
        private SolidBrush _brush = new SolidBrush(Color.OrangeRed);

        private Font _fontSmall = new Font("Arial", 12, FontStyle.Bold);
        private SolidBrush _brushSmall = new SolidBrush(Color.OrangeRed);

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
                Point scaled = this.GetOffsetPoint(point.Point);
                graphics.DrawEllipse(_pen, scaled.X - 2, scaled.Y - 2, 5, 5);

                if (settings.DrawLabels)
                {
                    graphics.DrawString(point.DistanceFromLast.ToString("0.000"), _fontSmall, _brushSmall, scaled.X + 20, scaled.Y + 10);
                    graphics.DrawString(point.DistanceFromBegining.ToString("0.000"), _fontSmall, _brushSmall, scaled.X + 20, scaled.Y + 22);
                }

            }
        }

        private void DrawLines(Graphics graphics, Route route)
        {
            if (route.Count > 1)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLines(route.Points().Select(x => this.GetOffsetPoint(x.Point)).ToArray());
                graphics.DrawPath(_pen, path);
            }
        }

        private void DrawDistance(Graphics graphics, Route route)
        {
            graphics.DrawString(route.WholeDictance.ToString("0.000") + " km", _font, _brush, 0, 0);
        }
    }
}
