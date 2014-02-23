namespace CaveDwellers.Core.Movement
{
    public interface IUserMoveable : IMoveable
    {
        void StartMoving(Direction direction);
    }
}