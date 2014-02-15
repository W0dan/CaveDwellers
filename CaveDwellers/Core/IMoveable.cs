namespace CaveDwellers.Core
{
    public interface IMoveable
    {
        int Speed { get; }
        void Move(Direction direction);
        void SetWorldMatrix(WorldMatrix worldMatrix);
    }
}