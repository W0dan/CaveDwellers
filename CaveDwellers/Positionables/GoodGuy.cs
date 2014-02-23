using System;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Positionables.Monsters;
using CaveDwellers.Resources;

namespace CaveDwellers.Positionables
{
    public class GoodGuy : IUserMoveable, IPositionable, IWantToBeNotifiedOfGameTimeElapsedEvents
    {
        private readonly WorldMatrix _worldMatrix;
        private Direction _direction;
        private int _life = 3;
        private DateTime? _timeOutFrom;

        public GoodGuy(WorldMatrix worldMatrix)
        {
            _worldMatrix = worldMatrix;
        }

        public int Speed
        {
            get { return 50; }
        }

        public void StopMoving()
        {
            IsMoving = false;
        }

        public void Move()
        {
            if (IsMoving)
            {
                _worldMatrix.Move(this, _direction);
            }
        }

        public void StartMoving(Direction direction)
        {
            if (IsMoving)
            {
                return;
            }

            _direction = direction;
            IsMoving = true;
            _worldMatrix.Move(this, direction);
        }

        private bool IsMoving { get; set; }

        public Size Size
        {
            get { return new Size(10, 10); }
        }

        public ImageName Sprite
        {
            get {
                return HasTimeout() 
                    ? Images.SmileyTimeout 
                    : Images.Smiley;
            }
        }

        public void CollidedWith(IPositionable @object)
        {
            if (HasTimeout() || !(@object is Monster)) return;

            _life--;
            _timeOutFrom = DateTime.Now;
        }

        private bool HasTimeout()
        {
            return _timeOutFrom.HasValue;
        }

        public void Notify(GameTime gameTime)
        {
            if (!_timeOutFrom.HasValue) return;

            if (gameTime.Time.Subtract(_timeOutFrom.Value).TotalSeconds >= 1)
            {
                _timeOutFrom = null;
            }
        }
    }
}