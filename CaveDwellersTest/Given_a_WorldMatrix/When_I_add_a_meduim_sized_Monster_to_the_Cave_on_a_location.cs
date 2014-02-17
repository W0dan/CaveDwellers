using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;
using CaveDwellersTest.MonstersForTest;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_WorldMatrix
{
    public class When_I_add_a_meduim_sized_Monster_to_the_WorldMatrix_on_a_location : AAATest
    {
        private WorldMatrix _worldMatrix;
        private MediumSizedMonster _theMonster;

        protected override void Arrange()
        {
            _worldMatrix = new WorldMatrix();
            _theMonster = new MediumSizedMonster(_worldMatrix);
        }

        protected override void Act()
        {
            _worldMatrix.Add(new Point(5, 5), _theMonster);
        }

        [Test]
        public void It_exists_on_every_matching_location_in_the_WorldMatrix()
        {
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(4, 4)));
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(4, 5)));

            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(5, 4)));
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(5, 5)));
        }

        [Test]
        public void It_does_not_exist_on_another_location_in_the_WorldMatrix()
        {
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 4)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 5)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 6)));

            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(4, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(4, 6)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(5, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(5, 6)));

            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 4)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 5)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 6)));
        }
    }
}