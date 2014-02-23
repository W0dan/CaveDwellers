using System;
using System.Windows;

namespace CaveDwellers.Mathematics
{
    public static class Calculator
    {
        public static double ToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        public static double CalculateDirection(Point a, Point b)
        {
            var dX = a.X - b.X;
            var dY = a.Y - b.Y;

            return (int)dX <= 0
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

            var correctedDirection = direction - (Math.PI/2);
            var x = (int)(currentLocation.X + Math.Cos(correctedDirection) * distanceToMove);
            var y = (int)(currentLocation.Y + Math.Sin(correctedDirection) * distanceToMove);

            return new Point(x, y);
        }
    }
}