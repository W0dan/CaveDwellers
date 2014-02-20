using System.Windows;

namespace CaveDwellers.Core
{
    public interface IMoveable
    {
        int Speed { get; }
        void Move(Direction direction);
        Point NextDestination { get; }
        bool IsMoving { get; }
    }
}