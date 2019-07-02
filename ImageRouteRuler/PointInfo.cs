using System;
using System.Drawing;

namespace ImageRouteRuler
{
    public class PointInfo : ICloneable
    {
        public Point Point { get; set; }
        public decimal DistanceFromLast { get; set; }
        public decimal DistanceFromBegining { get; set; }

        public PointInfo(Point point, decimal distanceFromLast, decimal distanceFromBegining)
        {
            Point = point;
            DistanceFromLast = distanceFromLast;
            DistanceFromBegining = distanceFromBegining;
        }

        public object Clone()
        {
            return new PointInfo(Point, DistanceFromLast, DistanceFromBegining);
        }
    }
}
