using System;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Resources;

namespace CaveDwellers.Positionables.Monsters
{
    public class Monster : IPositionable, IAutoMoveable
    {
        protected static readonly Random Randomizer = new Random();

        private readonly WorldMatrix _worldMatrix;

        public Monster(WorldMatrix worldMatrix)
        {
            _worldMatrix = worldMatrix;
        }

        public virtual Size Size
        {
            get { return new Size(10, 10); }
        }

        public virtual int Speed { get { return 40; } }

        public ImageName Sprite
        {
            get { return Images.Ghost; }
        }

        public void StopMoving()
        {
            IsMoving = false;
        }

        public void Move()
        {
            if (IsMoving)
            {
                _worldMatrix.Move(this);
                return;
            }

            var x = Randomizer.Next(1000);
            var y = Randomizer.Next(1000);
            NextDestination = new Point(x, y);
            IsMoving = true;
            _worldMatrix.Move(this);
        }

        public Point NextDestination { get; private set; }

        private bool IsMoving { get; set; }

        public void CollidedWith(IPositionable @object)
        {
            var goodGuy = @object as GoodGuy;
            if (goodGuy != null)
            {
                goodGuy.CollidedWith(this);
            }
        }
    }
}