using System;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Core.TimeManagement;
using CaveDwellers.Utility;
using CaveDwellersTest.MonstersForTest;
using Moq;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Monster_with_size_3x3_and_speed_40
{
    public class When_the_worldMatrix_is_Notified_of_GameTimeElapsed_and_the_monsters_destination_is_NORTH : AAATest
    {
        private LargeMonster _monster;
        private WorldMatrix _worldMatrix;
        private readonly Point _oldLocation = new Point(-50, 0);
        private readonly Point _expectedNewLocation = new Point(-50, -4);
        private Mock<IRnd> _rndMock;

        protected override void Arrange()
        {
            _rndMock = new Mock<IRnd>();
            _rndMock
                .Setup(r => r.Next(It.IsAny<int>()))
                .Returns(-50);
            _worldMatrix = new WorldMatrix();
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 0), 100));
            _monster = new LargeMonster(_worldMatrix, _rndMock.Object);
            _worldMatrix.Add(_oldLocation, _monster);
        }

        protected override void Act()
        {
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 100), 100));
        }

        [Test]
        public void The_monster_is_positioned_4_higher_in_the_WorldMatrix()
        {
            Assert.AreEqual(_expectedNewLocation, _worldMatrix.GetLocationOf(_monster));
        }

        [Test]
        public void A_reference_to_the_monster_is_found_at_the_new_location()
        {
            var expectedX = _expectedNewLocation.X;
            var expectedY = _expectedNewLocation.Y;

            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX - 1, expectedY - 1)));
            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX, expectedY - 1)));
            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX + 1, expectedY - 1)));

            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX - 1, expectedY)));
            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX, expectedY)));
            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX + 1, expectedY)));

            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX - 1, expectedY + 1)));
            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX, expectedY + 1)));
            Assert.AreSame(_monster, _worldMatrix.GetObjectAt(new Point(expectedX + 1, expectedY + 1)));
        }

        [Test]
        public void No_reference_to_the_monster_is_found_at_the_old_location()
        {
            var oldX = _oldLocation.X;
            var oldY = _oldLocation.Y;

            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX - 1, oldY - 1)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX, oldY - 1)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX + 1, oldY - 1)));

            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX - 1, oldY)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX, oldY)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX + 1, oldY)));

            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX - 1, oldY + 1)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX, oldY + 1)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(oldX + 1, oldY + 1)));
        }
    }
}