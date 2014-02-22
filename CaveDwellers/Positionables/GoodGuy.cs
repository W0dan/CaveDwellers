using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Resources;

namespace CaveDwellers.Positionables
{
    public class GoodGuy : IUserMoveable, IPositionable
    {
        private readonly WorldMatrix _worldMatrix;
        private Direction _direction;

        public GoodGuy(WorldMatrix worldMatrix)
        {
            _worldMatrix = worldMatrix;
        }

        public int Speed
        {
            get { return 50; }
        }

        public Point NextDestination
        {
            get { throw new System.NotImplementedException(); }
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
            get { return Images.Smiley; }
        }
    }
}