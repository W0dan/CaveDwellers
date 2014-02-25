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

        public static NumberBetween Between(this double number, double otherNumber)
        {
            return new NumberBetween(number, otherNumber);
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

            var x = 0;
            var y = 0;

            var correctedDirection = direction - (Math.PI / 2);
            if (correctedDirection.Between(0).And(Math.PI / 2))
            {
                x = (int)(currentLocation.X + Math.Cos(correctedDirection) * distanceToMove);
                y = (int)(currentLocation.Y - Math.Sin(correctedDirection) * distanceToMove);
            }
            else if (correctedDirection.Between(Math.PI / 2).And(Math.PI))
            {
                x = (int)(currentLocation.X + Math.Cos(correctedDirection) * distanceToMove);
                y = (int)(currentLocation.Y + Math.Sin(correctedDirection) * distanceToMove);
            }
            else if (correctedDirection.Between(Math.PI).And(Math.PI + Math.PI / 2))
            {
                x = (int)(currentLocation.X + Math.Cos(correctedDirection) * distanceToMove);
                y = (int)(currentLocation.Y - Math.Sin(correctedDirection) * distanceToMove);
            }
            else if (correctedDirection.Between(-Math.PI).And(0))
            {
                x = (int)(currentLocation.X + Math.Cos(correctedDirection) * distanceToMove);
                y = (int)(currentLocation.Y + Math.Sin(correctedDirection) * distanceToMove);
            }

            return new Point(x, y);
        }
    }

    public class NumberBetween
    {
        private readonly double _number;
        private readonly double _otherNumber;

        public NumberBetween(double number, double otherNumber)
        {
            _number = number;
            _otherNumber = otherNumber;
        }

        public bool And(double number)
        {
            return (_otherNumber <= _number) && (_number < number);
        }
    }
}