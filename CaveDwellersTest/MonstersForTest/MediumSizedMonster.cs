using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;
using CaveDwellers.Utility;

namespace CaveDwellersTest.MonstersForTest
{
    public class MediumSizedMonster : Monster
    {
        public MediumSizedMonster(WorldMatrix worldMatrix)
            : base(worldMatrix, new Rnd(200, 200))
        {
        }

        public override Size Size
        {
            get { return new Size(2, 2); }
        }
    }
}