using System;

namespace CaveDwellers.Utility
{
    public class Rnd : IRnd
    {
        private readonly int _maxXValue;
        private readonly int _maxYValue;
        private readonly Random _random = new Random();

        public Rnd(int maxXValue, int maxYValue)
        {
            _maxXValue = maxXValue;
            _maxYValue = maxYValue;
        }

        public int NextX()
        {
            return _random.Next(_maxXValue);
        }

        public int NextY()
        {
            return _random.Next(_maxYValue);
        }
    }
}