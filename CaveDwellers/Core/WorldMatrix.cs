using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellers.Core
{
    public class WorldMatrix : IWantToBeNotifiedOfGameTimeElapsedEvents
    {
        private const int Scale = 1;
        private readonly Dictionary<IPositionable, Point> _locations = new Dictionary<IPositionable, Point>();
        private readonly Dictionary<Point, IPositionable> _objects = new Dictionary<Point, IPositionable>();

        public void Add(int x, int y, IPositionable @object)
        {
            Add(new Point(x*Scale, y*Scale), @object);
        }

        public void Add(Point point, IPositionable @object)
        {
            var width = @object.Size.Width*Scale;
            var height = @object.Size.Height*Scale;

            var wOffset = (width - width % 2) / 2;
            var hOffset = (height - height % 2) / 2;

            for (var w = 0; w < width; w++)
            {
                for (var h = 0; h < height; h++)
                {
                    var p = new Point(point.X - wOffset + w, point.Y - hOffset + h);
                    _objects.Add(p, @object);
                }
            }

            _locations.Add(@object, point);
        }

        private IPositionable IsCollision(IPositionable @object, Point newLocation)
        {
            var wOffset = (@object.Size.Width - @object.Size.Width % 2) / 2;
            var hOffset = (@object.Size.Height - @object.Size.Height % 2) / 2;

            for (var w = 0; w < @object.Size.Width; w++)
            {
                for (var h = 0; h < @object.Size.Height; h++)
                {
                    var p = new Point(newLocation.X - wOffset + w, newLocation.Y - hOffset + h);
                    if (_objects.ContainsKey(p) && _objects[p] != null && _objects[p] != @object)
                        return _objects[p];
                }
            }

            return null;
        }

        public IPositionable GetObjectAt(int x, int y)
        {
            return GetObjectAt(new Point(x, y));
        }

        public IPositionable GetObjectAt(Point point)
        {
            return _objects.ContainsKey(point)
                       ? _objects[point]
                       : null;
        }

        public Point? GetLocationOf(IPositionable @object)
        {
            return _locations.ContainsKey(@object)
                ? _locations[@object]
                : (Point?)null;
        }

        private void RemoveFromLocation(IPositionable @object)
        {
            var objectsToRemove = (from o in _objects where o.Value == @object select o.Key).ToList();

            objectsToRemove.ForEach(o => _objects.Remove(o));

            _locations.Remove(@object);
        }

        public void Move(IPositionable @object, Direction direction, int speed)
        {
            var p = GetLocationOf(@object);
            if (!p.HasValue)
                return;

            var oldLocation = new Point(p.Value.X, p.Value.Y);
            Point newLocation;

            switch (direction)
            {
                case Direction.Up:
                    newLocation = new Point(oldLocation.X, oldLocation.Y - speed);
                    break;
                case Direction.Down:
                    newLocation = new Point(oldLocation.X, oldLocation.Y + speed);
                    break;
                case Direction.Left:
                    newLocation = new Point(oldLocation.X - speed, oldLocation.Y);
                    break;
                case Direction.Right:
                    newLocation = new Point(oldLocation.X + speed, oldLocation.Y);
                    break;
                default:
                    return;
            }

            if (IsCollision(@object, newLocation) != null)
                return;

            RemoveFromLocation(@object);
            Add(newLocation, @object);

        }

        public IEnumerable<KeyValuePair<IPositionable, Point>> GetObjects()
        {
            return _locations;
        }

        private IEnumerable<T> GetObjects<T>()
        {
            return (from posit in _locations where posit.Key is T select (T)posit.Key).ToList();
        }

        public void Notify(GameTime gameTime)
        {
            foreach (var m in GetObjects<Monster>())
            {
                m.Move();
            }
        }
    }
}