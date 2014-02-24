using System;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Core.TimeManagement;
using CaveDwellers.Mathematics;
using CaveDwellers.Positionables.Monsters;
using CaveDwellers.Utility;
using CaveDwellersTest.MonstersForTest;
using Moq;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_Monster
{
    public class When_the_worldMatrix_is_Notified_of_GameTimeElapsed_and_the_monsters_destination_is_NORTHEAST : AAATest
    {
        private Monster _monster;
        private WorldMatrix _worldMatrix;
        private readonly Point _oldLocation = new Point(-50, 50);
        private Mock<IRnd> _rndMock;
        private double _oldDistance;

        protected override void Arrange()
        {
            _rndMock = new Mock<IRnd>();
            _rndMock
                .Setup(r => r.Next(It.IsAny<int>()))
                .Returns(0);
            _worldMatrix = new WorldMatrix();
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 0), 100));
            _monster = new Monster1x1(_worldMatrix, _rndMock.Object);
            _worldMatrix.Add(_oldLocation, _monster);
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 100), 100));
            var locationOfMonster = _worldMatrix.GetLocationOf(_monster);
            Assert.IsNotNull(locationOfMonster);
            _oldDistance = Calculator.CalculateDistance(locationOfMonster.Value, _monster.NextDestination);
        }

        protected override void Act()
        {
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 100), 100));
        }

        [Test]
        public void The_distance_between_itself_and_the_destination_becomes_smaller()
        {
            var locationOfMonster = _worldMatrix.GetLocationOf(_monster);
            Assert.IsNotNull(locationOfMonster);
            var newDistance = Calculator.CalculateDistance(locationOfMonster.Value, _monster.NextDestination);

            Assert.True(locationOfMonster.Value.X > -50 && locationOfMonster.Value.Y < 50, string.Format("the new location must lie closer to (0,0), but is now {0}", locationOfMonster));
            Assert.True(_oldDistance > newDistance, string.Format("the new distance ({0}) is not smaller than the old distance ({1})", newDistance, _oldDistance));
        }
    }
}