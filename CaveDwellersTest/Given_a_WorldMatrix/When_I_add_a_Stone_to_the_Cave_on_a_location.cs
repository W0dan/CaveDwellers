using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_WorldMatrix
{
    public class When_I_add_a_Stone_to_the_WorldMatrix_on_a_location : AAATest
    {
        private WorldMatrix _worldMatrix;
        private Stone _theStone;

        protected override void Arrange()
        {
            _worldMatrix = new WorldMatrix();
            _theStone = new Stone();
        }

        protected override void Act()
        {
            _worldMatrix.Add(new Point(5, 5), _theStone);
        }

        [Test]
        public void It_exists_on_that_location_in_the_WorldMatrix()
        {
            Assert.AreSame(_theStone, _worldMatrix.GetObjectAt(new Point(5, 5)));
        }

        [Test]
        public void It_does_not_exist_on_another_location_in_the_WorldMatrix()
        {
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 5)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(5, 6)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 6)));
        }
    }
}