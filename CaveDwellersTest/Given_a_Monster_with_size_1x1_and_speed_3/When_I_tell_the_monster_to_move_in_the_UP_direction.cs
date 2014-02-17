using System.Windows;
using CaveDwellers.Core;
using CaveDwellersTest.MonstersForTest;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Monster_with_size_1x1_and_speed_3
{
    public class When_I_tell_the_monster_to_move_in_the_UP_direction : AAATest
    {
        private FastMonster _monster;
        private WorldMatrix _worldMatrix;
        private readonly Point _oldLocation = new Point(0, 0);
        private readonly Point _expectedNewLocation = new Point(0, -3);

        protected override void Arrange()
        {
            _worldMatrix = new WorldMatrix();
            _monster = new FastMonster(_worldMatrix);
            _worldMatrix.Add(_oldLocation, _monster);
        }

        protected override void Act()
        {
            _monster.Move(Direction.Up);
        }

        [Test]
        public void The_monster_is_positioned_1_higher_in_the_WorldMatrix()
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