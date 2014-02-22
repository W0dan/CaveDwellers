using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellersTest.MonstersForTest
{
    public class FastMonster : Monster
    {
        public FastMonster(WorldMatrix worldMatrix)
            : base(worldMatrix, new Rnd())
        {
        }

        public override int Speed { get { return 3; } }

        public override Size Size { get { return new Size(1, 1); } }
    }
}