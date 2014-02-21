using System.Windows;
using CaveDwellers.Mathematics;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Mathematics_Calculator
{
    public class When_CalculateDistance_is_called
    {
        [Test]
        public void Then_it_gets_10_for_2_points_that_have_the_same_x_but_differ_10_in_y()
        {
            var distance = Calculator.CalculateDistance(new Point(0, 0), new Point(0, 10));

            Assert.AreEqual(10, distance);
        }

        [Test]
        public void Then_it_gets_20_for_2_points_that_have_the_same_x_but_differ_20_in_y()
        {
            var distance = Calculator.CalculateDistance(new Point(0, 0), new Point(0, 20));

            Assert.AreEqual(20, distance);
        }

        [Test]
        public void Then_it_gets_10_for_2_points_that_have_the_same_y_but_differ_10_in_x()
        {
            var distance = Calculator.CalculateDistance(new Point(0, 0), new Point(10, 0));

            Assert.AreEqual(10, distance);
        }

        [Test]
        public void Then_it_gets_20_for_2_points_that_have_the_same_y_but_differ_20_in_x()
        {
            var distance = Calculator.CalculateDistance(new Point(0, 0), new Point(20, 0));

            Assert.AreEqual(20, distance);
        }

        [Test]
        public void Then_it_gets_5_for_2_points_that_have_x_differ_3_and_y_differ_4()
        {
            var distance = Calculator.CalculateDistance(new Point(0, 0), new Point(3, 4));

            Assert.AreEqual(5, distance);
        }

        [Test]
        public void Then_it_gets_5_for_2_points_that_have_x_differ_4_and_y_differ_3()
        {
            var distance = Calculator.CalculateDistance(new Point(0, 0), new Point(4, 3));

            Assert.AreEqual(5, distance);
        }
    }
}