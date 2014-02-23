using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;
using CaveDwellers.Utility;

namespace CaveDwellersTest.MonstersForTest
{
    public class FastMonster : Monster
    {
        public FastMonster(WorldMatrix worldMatrix, IRnd rnd)
            : base(worldMatrix, rnd)
        {
        }

        public override int Speed { get { return 80; } }

        public override Size Size { get { return new Size(1, 1); } }
    }
}