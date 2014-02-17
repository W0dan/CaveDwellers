using System.Collections.Generic;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellersTest.LevelsForTest
{
    public class TenByTenLevel
    {
        private readonly WorldMatrix _world = new WorldMatrix();

        public TenByTenLevel()
        {
            for (var x = 0; x < 10; x++)
            {
                _world.Add(x, 0, new Stone());
                _world.Add(x, 9, new Stone());
            }

            for (var y = 1; y < 9; y++)
            {
                _world.Add(0, y, new Stone());
                _world.Add(9, y, new Stone());
            }

            _world.Add(3, 3, new Monster(_world));
            _world.Add(3, 7, new Monster(_world));
            _world.Add(7, 3, new Monster(_world));
            _world.Add(7, 7, new Monster(_world));
        }

        public IEnumerable<KeyValuePair<Point, IPositionable>> GetObjects()
        {
            return _world.GetObjects();
        }

    }
}