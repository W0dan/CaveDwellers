using System;
using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Resources;

namespace CaveDwellers.Positionables.Monsters
{
    public class Monster : IPositionable, IMoveable
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

        public virtual int Speed { get { return 1; } }

        public void Move(Direction direction)
        {
            _worldMatrix.Move(this, direction, Speed);
        }

        public void Move()
        {
            var randomNumber = Randomizer.Next(4);
            Direction direction = 0;

            switch (randomNumber)
            {
                case 0:
                    direction = Direction.Up;
                    break;
                case 1:
                    direction = Direction.Down;
                    break;
                case 2:
                    direction = Direction.Left;
                    break;
                case 3:
                    direction = Direction.Right;
                    break;
            }

            Move(direction);
        }

        public ImageName Sprite
        {
            get { return Images.Ghost; }
        }
    }
}