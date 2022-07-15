using System;
using System.Drawing;

namespace ImageRouteRuler
{
    public class PointInfo : ICloneable
    {
        public Point Point { get; set; }
        public decimal DistanceFromLast { get; set; }
        public decimal DistanceFromBeginning { get; set; }

        public PointInfo(Point point, decimal distanceFromLast, decimal distanceFromBeginning)
        {
            Point = point;
            DistanceFromLast = distanceFromLast;
            DistanceFromBeginning = distanceFromBeginning;
        }

        public object Clone()
        {
            return new PointInfo(Point, DistanceFromLast, DistanceFromBeginning);
        }
    }
}
