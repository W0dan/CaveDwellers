using System.Collections.Generic;
using System.Windows;
using CaveDwellers.Positionables;

namespace CaveDwellers.Core
{
    public interface IWorldMatrix : IWantToBeNotifiedOfGameTimeElapsedEvents
    {
        void Add(int x, int y, IPositionable @object);
        void Add(Point point, IPositionable @object);
        IPositionable GetObjectAt(int x, int y);
        IPositionable GetObjectAt(Point point);
        Point? GetLocationOf(IPositionable @object);

        void Move<T>(T @object)
            where T : IAutoMoveable, IPositionable;

        void Move(GoodGuy goodGuy, Direction direction);
        IEnumerable<KeyValuePair<IPositionable, Point>> GetObjects();
    }
}