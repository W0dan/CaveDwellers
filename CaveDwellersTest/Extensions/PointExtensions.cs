using System;
using System.Windows;

namespace CaveDwellersTest.Extensions
{
    public static class PointExtensions
    {
        public static bool IsEqualTo(this Point thisPoint, Point point)
        {
            var x1 = (int)Math.Round(thisPoint.X, 0, MidpointRounding.AwayFromZero);
            var x2 = (int)Math.Round(point.X, 0, MidpointRounding.AwayFromZero);
            var y1 = (int)Math.Round(thisPoint.Y, 0, MidpointRounding.AwayFromZero);
            var y2 = (int)Math.Round(point.Y, 0, MidpointRounding.AwayFromZero);

            return x1 == x2 && y1 == y2;
        }
    }
}