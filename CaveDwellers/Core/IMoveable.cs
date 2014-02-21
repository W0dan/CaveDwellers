using System.Windows;

namespace CaveDwellers.Core
{
    public interface IMoveable
    {
        int Speed { get; }
        Point NextDestination { get; }

        void StopMoving();
    }
}