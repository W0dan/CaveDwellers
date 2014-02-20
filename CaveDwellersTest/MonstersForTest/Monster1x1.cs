using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellersTest.MonstersForTest
{
    public class Monster1x1 : Monster
    {
        public Monster1x1(WorldMatrix worldMatrix)
            : base(worldMatrix)
        {
        }

        public override Size Size { get { return new Size(1, 1); } }
    }
}