using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellersTest.MonstersForTest
{
    public class LargeMonster : Monster
    {
        public LargeMonster(WorldMatrix worldMatrix) : base(worldMatrix)
        {
        }

        public override Size Size
        {
            get { return new Size(3, 3); }
        }
    }
}