using System.Windows;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellersTest.MonstersForTest
{
    public class MediumSizedMonster : Monster
    {
        public override Size Size
        {
            get { return new Size(2, 2); }
        }
    }
}