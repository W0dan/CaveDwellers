using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CaveDwellers.Core
{
    public class WorldMatrix
    {
        private readonly Dictionary<IPositionable, Point> _locations = new Dictionary<IPositionable, Point>();
        private readonly Dictionary<Point, IPositionable> _objects = new Dictionary<Point, IPositionable>();

        public void Add(int x, int y, IPositionable @object)
        {
            Add(new Point(x, y), @object);
        }

        public void Add(Point point, IPositionable @object)
        {
            //@object.SetWorldMatrix(this);
            var wOffset = (@object.Size.Width - @object.Size.Width % 2) / 2;
            var hOffset = (@object.Size.Height - @object.Size.Height % 2) / 2;

            for (var w = 0; w < @object.Size.Width; w++)
            {
                for (var h = 0; h < @object.Size.Height; h++)
                {
                    var p = new Point(point.X - wOffset + w, point.Y - hOffset + h);
                    _objects.Add(p, @object);
                }
            }

            _locations.Add(@object, point);
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

            var oldLocation = p.Value;
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

            RemoveFromLocation(@object);
            Add(newLocation, @object);

        }

        public IEnumerable<KeyValuePair<Point, IPositionable>> GetObjects()
        {
            return _objects;
        }
    }
}