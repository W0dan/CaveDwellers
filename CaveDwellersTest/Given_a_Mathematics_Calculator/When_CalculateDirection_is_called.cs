using System.Windows;
using CaveDwellers.Mathematics;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Mathematics_Calculator
{
    public class When_CalculateDirection_is_called
    {
        [Test]
        public void Then_it_gets_045_for_2_points_that_have_an_equal_an_positive_x_and_y_distance()
        {
            var direction = Calculator.CalculateDirection(new Point(5, 7), new Point(10, 12));

            Assert.AreEqual(45D.ToRadians(), direction);
        }

        [Test]
        public void Then_it_gets_0_for_2_points_that_have_an_x_distance_of_0_and_a_negative_y_distance()
        {
            var direction = Calculator.CalculateDirection(new Point(0, 0), new Point(0, -7));

            Assert.AreEqual(0D.ToRadians(), direction);
        }

        [Test]
        public void Then_it_gets_090_for_2_points_that_have_a_y_distance_of_0_and_a_positive_x_distance()
        {
            var direction = Calculator.CalculateDirection(new Point(0, 0), new Point(5, 0));

            Assert.AreEqual(90D.ToRadians(), direction);
        }

        [Test]
        public void Then_it_gets_180_for_2_points_that_have_an_x_distance_of_0_and_a_postive_y_distance()
        {
            var direction = Calculator.CalculateDirection(new Point(0, 0), new Point(0, 7));

            Assert.AreEqual(180D.ToRadians(), direction);
        }

        [Test]
        public void Then_it_gets_270_for_2_points_that_have_a_y_distance_of_0_and_a_negative_x_distance()
        {
            var direction = Calculator.CalculateDirection(new Point(0, 0), new Point(-7, 0));

            Assert.AreEqual(270D.ToRadians(), direction);
        }

        [Test]
        public void Then_it_gets_225_for_2_points_that_have_a_postive_y_distance_and_an_equal_but_negative_x_distance()
        {
            var direction = Calculator.CalculateDirection(new Point(0, 0), new Point(-7, 7));

            Assert.AreEqual(225D.ToRadians(), direction);
        }

        [Test]
        public void Then_it_gets_315_for_2_points_that_have_a_negative_y_distance_and_an_equal_x_distance()
        {
            var direction = Calculator.CalculateDirection(new Point(0, 0), new Point(-7, -7));

            Assert.AreEqual(315D.ToRadians(), direction);
        }

    }
}