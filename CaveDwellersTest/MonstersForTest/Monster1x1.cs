using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;
using CaveDwellers.Utility;

namespace CaveDwellersTest.MonstersForTest
{
    public class Monster1x1 : Monster
    {
        public Monster1x1(IWorldMatrix worldMatrix, IRnd rnd)
            : base(worldMatrix, rnd)
        {
        }

        public override Size Size { get { return new Size(1, 1); } }
    }
}