using System.Windows;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellersTest.MonstersForTest
{
    public class LargeMonster : Monster
    {
        public override Size Size
        {
            get { return new Size(3, 3); }
        }
    }
}