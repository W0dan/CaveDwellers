using System.Collections.Generic;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables;
using CaveDwellers.Positionables.Monsters;
using CaveDwellersTest.MonstersForTest;
using CaveDwellersTest.StonesForTest;

namespace CaveDwellersTest.LevelsForTest
{
    public class TenByTenLevel
    {
        private readonly WorldMatrix _world = new WorldMatrix();

        public TenByTenLevel()
        {
            for (var x = 0; x < 10; x++)
            {
                _world.Add(x, 0, CreateStone());
                _world.Add(x, 9, CreateStone());
            }

            for (var y = 1; y < 9; y++)
            {
                _world.Add(0, y, CreateStone());
                _world.Add(9, y, CreateStone());
            }

            _world.Add(3, 3, CreateMonster());
            _world.Add(3, 7, CreateMonster());
            _world.Add(7, 3, CreateMonster());
            _world.Add(7, 7, CreateMonster());
        }

        private Monster CreateMonster()
        {
            return new Monster1x1(_world, new Rnd());
        }

        private static Stone CreateStone()
        {
            return new Stone1x1();
        }

        public IEnumerable<KeyValuePair<IPositionable, Point>> GetObjects()
        {
            return _world.GetObjects();
        }

    }
}