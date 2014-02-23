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
    public class When_the_worldMatrix_is_Notified_of_GameTimeElapsed_and_the_monsters_destination_is_NORTHish : AAATest
    {
        private WorldMatrix _worldMatrix;
        private Mock<IRnd> _rndMock;

        private Monster _monster1;
        private readonly Point _oldLocation1 = new Point(49, 100);
        private double _oldDistance1;

        private Monster _monster2;
        private readonly Point _oldLocation2 = new Point(51, 100);
        private double _oldDistance2;

        protected override void Arrange()
        {
            _rndMock = new Mock<IRnd>();
            _rndMock
                .Setup(r => r.Next(It.IsAny<int>()))
                .Returns(50);
            _worldMatrix = new WorldMatrix();
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 0), 100));

            _monster1 = new Monster1x1(_worldMatrix, _rndMock.Object);
            _monster2 = new Monster1x1(_worldMatrix, _rndMock.Object);
            _worldMatrix.Add(_oldLocation1, _monster1);
            _worldMatrix.Add(_oldLocation2, _monster2);

            //we need a first notify in order to have a baseline
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 100), 100));
            _oldDistance1 = GetDistance(_monster1);
            _oldDistance2 = GetDistance(_monster2);
        }

        private double GetDistance(Monster monster)
        {
            var locationOfMonster = _worldMatrix.GetLocationOf(monster);
            Assert.IsNotNull(locationOfMonster);
            return Calculator.CalculateDistance(locationOfMonster.Value, monster.NextDestination);
        }

        protected override void Act()
        {
            _worldMatrix.Notify(new GameTime(new DateTime(2014, 2, 23, 20, 0, 0, 100), 100));
        }

        [Test]
        public void The_distance_between_monster1_and_the_destination_becomes_smaller()
        {
            var locationOfMonster = _worldMatrix.GetLocationOf(_monster1);
            Assert.IsNotNull(locationOfMonster);
            var newDistance = Calculator.CalculateDistance(locationOfMonster.Value, _monster1.NextDestination);

            Assert.True(_oldDistance1 > newDistance, string.Format("the new distance ({0}) is not smaller than the old distance ({1})", newDistance, _oldDistance1));
        }

        [Test]
        public void The_distance_between_monster2_and_the_destination_becomes_smaller()
        {
            var locationOfMonster = _worldMatrix.GetLocationOf(_monster2);
            Assert.IsNotNull(locationOfMonster);
            var newDistance = Calculator.CalculateDistance(locationOfMonster.Value, _monster2.NextDestination);

            Assert.True(_oldDistance1 > newDistance, string.Format("the new distance ({0}) is not smaller than the old distance ({1})", newDistance, _oldDistance2));
        }
    }
}