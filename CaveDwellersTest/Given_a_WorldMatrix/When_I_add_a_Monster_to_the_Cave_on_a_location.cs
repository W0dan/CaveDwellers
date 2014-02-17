using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_WorldMatrix
{
    public class When_I_add_a_Monster_to_the_WorldMatrix_on_a_location : AAATest
    {
        private WorldMatrix _worldMatrix;
        private Monster _theMonster;
        private Monster _anotherMonster;
        private readonly Point _theMonstersLocation = new Point(5, 5);

        protected override void Arrange()
        {
            _worldMatrix = new WorldMatrix();
            _theMonster = new Monster(_worldMatrix);
            _anotherMonster = new Monster(_worldMatrix);
        }

        protected override void Act()
        {
            _worldMatrix.Add(_theMonstersLocation, _theMonster);
        }

        [Test]
        public void The_monster_exists_on_that_location_in_the_WorldMatrix()
        {
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(_theMonstersLocation));
        }

        [Test]
        public void The_monster_does_not_exist_on_another_location_in_the_worldMatrix()
        {
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 5)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(5, 6)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 6)));
        }

        [Test]
        public void The_worldMatrix_knows_the_monsters_location()
        {
            Assert.AreEqual(_theMonstersLocation, _worldMatrix.GetLocationOf(_theMonster));
        }

        [Test]
        public void The_worldMatrix_doesnt_know_the_location_of_a_monster_it_does_not_contain()
        {
            Assert.IsNull(_worldMatrix.GetLocationOf(_anotherMonster));
        }
    }
}