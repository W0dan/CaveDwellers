using System.Windows;

namespace CaveDwellers.Core
{
    public interface IMoveable
    {
        int Speed { get; }
        void StopMoving();
        void Move();
    }

    public interface IAutoMoveable : IMoveable
    {
        Point NextDestination { get; }
    }

    public interface IUserMoveable : IMoveable
    {
        void StartMoving(Direction direction);
    }
}