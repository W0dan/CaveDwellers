using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CaveDwellers.Mathematics;
using CaveDwellers.Positionables;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellers.Core
{
    public class WorldMatrix : IWantToBeNotifiedOfGameTimeElapsedEvents
    {
        private const int Scale = 1;
        private readonly Dictionary<IPositionable, Point> _locations = new Dictionary<IPositionable, Point>();
        private readonly Dictionary<Point, IPositionable> _objects = new Dictionary<Point, IPositionable>();
        private int _timeElapsed;

        public void Add(int x, int y, IPositionable @object)
        {
            Add(new Point(x * Scale, y * Scale), @object);
        }

        public void Add(Point point, IPositionable @object)
        {
            var width = @object.Size.Width * Scale;
            var height = @object.Size.Height * Scale;

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

        public void Move<T>(T @object)
            where T : IAutoMoveable, IPositionable
        {
            var currentLocation = _locations[@object];
            var destination = @object.NextDestination;

            var distance = Calculator.CalculateDistance(currentLocation, destination);
            var direction = Calculator.CalculateDirection(currentLocation, destination);

            var newLocation = Calculator.CalculateNewPosition(currentLocation, direction, @object.Speed, _timeElapsed);
            var distanceTraveled = Calculator.CalculateDistance(currentLocation, newLocation);

            var subject = IsCollision(@object, newLocation);
            if (distanceTraveled >= distance || subject != null)
            {
                @object.StopMoving();
                @object.CollidedWith(subject);
            }
            else
            {
                RemoveFromLocation(@object);
                Add(newLocation, @object);
            }
        }

        public void Move(GoodGuy goodGuy, Direction direction)
        {
            var currentLocation = _locations[goodGuy];
            var directionAngle = ((double) direction).ToRadians();
            var newLocation = Calculator.CalculateNewPosition(currentLocation, directionAngle, goodGuy.Speed, _timeElapsed);

            var subject = IsCollision(goodGuy, newLocation);
            if (subject != null)
            {
                goodGuy.StopMoving();
                goodGuy.CollidedWith(subject);
            }
            else
            {
                RemoveFromLocation(goodGuy);
                Add(newLocation, goodGuy);
            }
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
            _timeElapsed = gameTime.MillisecondsElapsed;
            foreach (var m in GetObjects<IMoveable>())
            {
                m.Move();
            }
        }
    }
}