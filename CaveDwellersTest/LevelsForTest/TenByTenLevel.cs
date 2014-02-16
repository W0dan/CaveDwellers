using System.Collections.Generic;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellersTest.LevelsForTest
{
    public class TenByTenLevel
    {
        public WorldMatrix World { get; private set; }

        public TenByTenLevel()
        {
            World = new WorldMatrix();

            for (var x = 0; x < 10; x++)
            {
                World.Add(x, 0, new Stone());
                World.Add(x, 9, new Stone());
            }

            for (var y = 1; y < 9; y++)
            {
                World.Add(0, y, new Stone());
                World.Add(9, y, new Stone());
            }

            World.Add(3, 3, new Monster());
            World.Add(3, 7, new Monster());
            World.Add(7, 3, new Monster());
            World.Add(7, 7, new Monster());
        }

        public IEnumerable<KeyValuePair<Point, IPositionable>> GetObjects()
        {
            return World.GetObjects();
        }

    }
}