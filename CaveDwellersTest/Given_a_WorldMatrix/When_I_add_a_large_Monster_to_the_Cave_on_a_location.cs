using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Utility;
using CaveDwellersTest.MonstersForTest;
using NUnit.Framework;

namespace CaveDwellersTest.Given_a_WorldMatrix
{
    public class When_I_add_a_large_Monster_to_the_WorldMatrix_on_a_location : AAATest
    {
        private WorldMatrix _worldMatrix;
        private LargeMonster _theMonster;

        protected override void Act()
        {
            _worldMatrix.Add(new Point(5, 5), _theMonster);
        }

        protected override void Arrange()
        {
            _worldMatrix = new WorldMatrix();
            _theMonster = new LargeMonster(_worldMatrix, new Rnd(200,200));
        }

        [Test]
        public void It_exists_on_every_matching_location_in_the_WorldMatrix()
        {
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(4, 4)));
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(4, 5)));
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(4, 6)));

            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(5, 4)));
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(5, 5)));
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(5, 6)));

            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(6, 4)));
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(6, 5)));
            Assert.AreSame(_theMonster, _worldMatrix.GetObjectAt(new Point(6, 6)));
        }

        [Test]
        public void It_does_not_exist_on_another_location_in_the_WorldMatrix()
        {
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 4)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 5)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 6)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(3, 7)));

            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(4, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(4, 7)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(5, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(5, 7)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(6, 7)));

            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(7, 3)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(7, 4)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(7, 5)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(7, 6)));
            Assert.IsNull(_worldMatrix.GetObjectAt(new Point(7, 7)));
        }
    }
}