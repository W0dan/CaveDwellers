using System;
using System.Windows;

namespace CaveDwellers.Mathematics
{
    public static class Calculator
    {
        public static double ToDegrees(this double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        public static double ToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        public static bool IsEqualTo(this double thisNumber, double number, double delta)
        {
            return Math.Abs(thisNumber - number) < delta;
        }

        public static bool IsEqualTo(this Point thisPoint, Point point, double delta)
        {
            return thisPoint.X.IsEqualTo(point.X, delta) && thisPoint.Y.IsEqualTo(point.Y, delta);
        }

        public static bool IsEqualTo(this Point thisPoint, Point point)
        {
            var x1 = (int)Math.Round(thisPoint.X, 0, MidpointRounding.AwayFromZero);
            var x2 = (int)Math.Round(point.X, 0, MidpointRounding.AwayFromZero);
            var y1 = (int)Math.Round(thisPoint.Y, 0, MidpointRounding.AwayFromZero);
            var y2 = (int)Math.Round(point.Y, 0, MidpointRounding.AwayFromZero);

            return x1 == x2 && y1 == y2;
        }

        private static int ToInt(this double number)
        {
            return (int)number;
        }

        public static double CalculateDirection(Point a, Point b)
        {
            var dX = a.X - b.X;
            var dY = a.Y - b.Y;

            return dX.ToInt() <= 0
                ? -(Math.Atan(dY / dX) - (Math.PI / 2))
                : (Math.PI * 2) + (Math.Atan(dY / dX) - (Math.PI / 2));
        }

        public static double CalculateDistance(Point a, Point b)
        {
            var dY = b.Y - a.Y;
            var dX = b.X - a.X;

            return Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
        }

        public static Point CalculateNewPosition(Point currentLocation, double direction, int speed, int timeElapsed)
        {
            var distanceToMove = (int)((double)speed * timeElapsed / 1000);

            var x = (int)(currentLocation.X + Math.Cos(direction - (Math.PI / 2)) * distanceToMove);
            var y = (int)(currentLocation.Y + Math.Sin(direction - (Math.PI / 2)) * distanceToMove);

            return new Point(x, y);
        }
    }
}