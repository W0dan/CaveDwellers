using System.Windows;
using CaveDwellers.Mathematics;
using CaveDwellersTest.Extensions;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Mathematics_Calculator
{
    public class When_CalculateNewPosition_is_called
    {
        [Test]
        public void It_sets_the_new_position_to_30_10_when_the_initial_position_is_10_10_and_the_speed_is_20_and_the_direction_is_90_degrees_and_the_timeElapsed_is_1000()
        {
            var result = Calculator.CalculateNewPosition(new Point(10, 10), 90.0.ToRadians(), 20, 1000);

            Assert.AreEqual(new Point(30, 10), result);
        }

        [Test]
        public void It_sets_the_new_position_to_minus_10_10_when_the_initial_position_is_10_10_and_the_speed_is_20_and_the_direction_is_270_degrees_and_the_timeElapsed_is_1000()
        {
            var result = Calculator.CalculateNewPosition(new Point(10, 10), 270D.ToRadians(), 20, 1000);

            var expectedResult = new Point(-10, 10);
            Assert.IsTrue(expectedResult.IsEqualTo(result), string.Format("{0} is not equal to {1}", expectedResult, result));
        }

        [Test]
        public void It_sets_the_new_position_to_10_08_when_the_initial_position_is_10_10_and_the_speed_is_2_and_the_direction_is_180_degrees_and_the_timeElapsed_is_1000()
        {
            var result = Calculator.CalculateNewPosition(new Point(10, 10), 180D.ToRadians(), 2, 1000);

            var expectedResult = new Point(10,12);
            Assert.IsTrue(expectedResult.IsEqualTo(result), string.Format("{0} is not equal to {1}", expectedResult, result));
        }

        [Test]
        public void It_sets_the_new_position_to_24_24_when_the_initial_position_is_10_10_and_the_speed_is_20_and_the_direction_is_45_degrees_and_the_timeElapsed_is_1000()
        {
            var result = Calculator.CalculateNewPosition(new Point(10, 10), 45D.ToRadians(), 20, 1000);

            var expectedResult = new Point(24, -4);
            Assert.IsTrue(expectedResult.IsEqualTo(result), string.Format("{0} is not equal to {1}", expectedResult, result));
        }
    }
}