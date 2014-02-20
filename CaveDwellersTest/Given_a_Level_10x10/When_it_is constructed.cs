using System.Linq;
using System.Windows;
using CaveDwellers.Positionables;
using CaveDwellers.Positionables.Monsters;
using CaveDwellersTest.LevelsForTest;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Level_10x10
{
    public class When_it_is_constructed : AAATest
    {
        private TenByTenLevel _level;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _level = new TenByTenLevel();
        }

        [Test]
        public void It_contains_a_wall_surrounding_it()
        {
            var objects = _level.GetObjects().Where(o => o.Value == new Point(0, 0)
                                                 || o.Value == new Point(1, 0)
                                                 || o.Value == new Point(2, 0)
                                                 || o.Value == new Point(3, 0)
                                                 || o.Value == new Point(4, 0)
                                                 || o.Value == new Point(5, 0)
                                                 || o.Value == new Point(6, 0)
                                                 || o.Value == new Point(7, 0)
                                                 || o.Value == new Point(8, 0)
                                                 || o.Value == new Point(9, 0)
                                                 || o.Value == new Point(0, 1) || o.Value == new Point(9, 1)
                                                 || o.Value == new Point(0, 2) || o.Value == new Point(9, 2)
                                                 || o.Value == new Point(0, 3) || o.Value == new Point(9, 3)
                                                 || o.Value == new Point(0, 4) || o.Value == new Point(9, 4)
                                                 || o.Value == new Point(0, 5) || o.Value == new Point(9, 5)
                                                 || o.Value == new Point(0, 6) || o.Value == new Point(9, 6)
                                                 || o.Value == new Point(0, 7) || o.Value == new Point(9, 7)
                                                 || o.Value == new Point(0, 8) || o.Value == new Point(9, 8)
                                                 || o.Value == new Point(0, 9)
                                                 || o.Value == new Point(1, 9)
                                                 || o.Value == new Point(2, 9)
                                                 || o.Value == new Point(3, 9)
                                                 || o.Value == new Point(4, 9)
                                                 || o.Value == new Point(5, 9)
                                                 || o.Value == new Point(6, 9)
                                                 || o.Value == new Point(7, 9)
                                                 || o.Value == new Point(8, 9)
                                                 || o.Value == new Point(9, 9)).ToList();

            Assert.AreEqual(36, objects.Count);

            foreach (var o in objects)
            {
                Assert.IsInstanceOf<Stone>(o.Key);
            }
        }

        [Test]
        public void It_contains_a_couple_of_monsters()
        {
            var objects = _level.GetObjects().Where(o => o.Value == new Point(3, 3)
                || o.Value == new Point(7, 3)
                || o.Value == new Point(3, 7)
                || o.Value == new Point(7, 7)).ToList();

            Assert.AreEqual(4, objects.Count);

            foreach (var o in objects)
            {
                Assert.IsInstanceOf<Monster>(o.Key);
            }
        }
    }
}