using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellersTest.MonstersForTest
{
    public class FastMonster : Monster
    {
        public FastMonster(WorldMatrix worldMatrix) : base(worldMatrix)
        {
        }

        public override int Speed { get { return 3; } }
    }
}