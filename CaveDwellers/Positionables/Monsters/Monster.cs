using System.Windows;
using CaveDwellers.Core;

namespace CaveDwellers.Positionables.Monsters
{
    public class Monster : IPositionable, IMoveable
    {
        private WorldMatrix _worldMatrix;

        public virtual Size Size
        {
            get { return new Size(1, 1); }
        }

        public virtual int Speed { get { return 1; } }

        public void Move(Direction direction)
        {
            _worldMatrix.Move(this, direction, Speed);
        }

        public void SetWorldMatrix(WorldMatrix worldMatrix)
        {
            _worldMatrix = worldMatrix;
        }
    }
}