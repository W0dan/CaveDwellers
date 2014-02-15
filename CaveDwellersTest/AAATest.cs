using NUnit.Framework;

namespace CaveDwellersTest
{
    [TestFixture]
    public abstract class AAATest
    {
        protected abstract void Arrange();
        protected abstract void Act();
        
        [TestFixtureSetUp]
        public void ArrangeAct()
        {
            Arrange();
            Act();
        }
    }
}