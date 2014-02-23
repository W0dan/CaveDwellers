namespace CaveDwellers.Core.Movement
{
    public interface IMoveable
    {
        int Speed { get; }
        void StopMoving();
        void Move();
        void CollidedWith(IPositionable @object);
    }
}