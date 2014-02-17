using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Monster_with_size_1x1_and_speed_1
{
    public class When_I_tell_the_monster_to_move_in_the_RIGHT_direction : AAATest
    {
        private Monster _monster;
        private WorldMatrix _worldMatrix;
        private readonly Point _expectedNewLocation = new Point(1, 0);
        private readonly Point _oldLocation = new Point(0, 0);

        protected override void Arrange()
        {
            _worldMatrix = new WorldMatrix();
            _monster = new Monster(_worldMatrix);
            _worldMatrix.Add(_oldLocation, _monster);
        }

        protected override void Act()
        {
            _monster.Move(Direction.Right);
        }

        [Test]
        public void The_monster_is_positioned_1_more_to_the_right_in_the_WorldMatrix()
        {
            Assert.AreEqual(_expectedNewLocation, _worldMatrix.GetLocationOf(_monster));
        }

        [Test]
        public void A_reference_to_the_monster_is_found_at_the_new_location()
        {
            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(_expectedNewLocation));
        }

        [Test]
        public void No_reference_to_the_monster_is_found_at_the_old_location()
        {
            Assert.IsNull(_worldMatrix.GetObjectAt(_oldLocation));
        }
    }
}