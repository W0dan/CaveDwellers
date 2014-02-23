using System;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;
using CaveDwellersTest.MonstersForTest;
using Moq;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Monster_with_size_1x1_and_speed_40
{
    public class When_the_worldMatrix_is_Notified_of_GameTimeElapsed_and_the_monsters_destination_is_SOUTH : AAATest
    {
        private Monster _monster;
        private WorldMatrix _worldMatrix;
        private readonly Point _oldLocation = new Point(50, 0);
        private readonly Point _expectedNewLocation = new Point(50, 4);
        private Mock<IRnd> _rndMock;

        protected override void Arrange()
        {
            _rndMock = new Mock<IRnd>();
            _rndMock
                .Setup(r => r.Next(It.IsAny<int>()))
                .Returns(50);
            _worldMatrix = new WorldMatrix();
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 0), 100));
            _monster = new Monster1x1(_worldMatrix, _rndMock.Object);
            _worldMatrix.Add(_oldLocation, _monster);
        }

        protected override void Act()
        {
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 100), 100));
        }

        /// <summary>
        ///distance travelled == speed * timeElapsed (seconds)
        ///=> 40 * 0.1 = 4
        /// </summary>
        [Test]
        public void The_monster_is_positioned_4_lower_in_the_WorldMatrix()
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