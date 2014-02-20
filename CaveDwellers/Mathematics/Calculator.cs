using System;
using System.Windows;

namespace CaveDwellers.Mathematics
{
    public static class Calculator
    {
        private static double ToDegrees(this double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        private static int ToInt(this double number)
        {
            return (int) number;
        }

        public static double CalculateDirection(Point a, Point b)
        {
            var dX = a.X - b.X;
            var dY = a.Y - b.Y;

            return dX.ToInt() <= 0 
                ? -(Math.Atan(dY/dX).ToDegrees() - 90) 
                : 360 + (Math.Atan(dY/dX).ToDegrees() - 90);
        }

        public static double CalculateDistance(Point a, Point b)
        {
            return 0;
        }
    }
}