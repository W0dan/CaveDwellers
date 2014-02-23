using System.Windows;

namespace CaveDwellers.Core.Movement
{
    public interface IAutoMoveable : IMoveable
    {
        Point NextDestination { get; }
    }
}