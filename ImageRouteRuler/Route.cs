using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ImageRouteRuler
{
    public class Route
    {
        private List<PointInfo> _points;
        private readonly Settings _settings;

        public Route(Settings settings)
        {
            _settings = settings;
            _points = new List<PointInfo>();
        }


        public int Count => _points.Count;

        public decimal WholeDistance => Convert.ToDecimal(_points.Count > 0 ? _points.Last().DistanceFromBeginning : 0);

        public void AddRange(IEnumerable<Point> points)
        {
            foreach (var point in points)
            {
                _points.Add(CreatePointInfo(point));
            }
        }

        public void AddPoint(Point point)
        {

            _points.Add(CreatePointInfo(point));
        }

        public void DeleteLast()
        {
            if (_points.Count > 0)
                _points.RemoveAt(_points.Count - 1);
        }

        public void DeleteAll()
        {
            _points.RemoveAll(x => true);
        }

        public IEnumerable<PointInfo> Points()
        {
            return _points.AsEnumerable();
        }

        public void Recalculate()
        {
            var routeCopy = _points.Select(x => x.Clone()).ToList();
            _points = new List<PointInfo>();

            for (var i = 0; i < routeCopy.Count; i++)
            {
                var point = ((PointInfo)routeCopy[i]).Point;
                _points.Add(CreatePointInfo(point));
            }
        }

        private PointInfo CreatePointInfo(Point point)
        {
            if (_points.Count == 0)
                return new PointInfo(point, 0, 0);


            var distance = Convert.ToDecimal(PixelsToKm(Distance(_points.Last().Point, point)));
            var distFromBeginning = _points.Last().DistanceFromBeginning + distance;

            return new PointInfo(point, distance, distFromBeginning);

        }

        private double Distance(Point from, Point to)
        {
            return Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));
        }

        private double PixelsToKm(double distance)
        {
            return (distance / _settings.Dpc * _settings.ScaleKm);
        }


    }
}
