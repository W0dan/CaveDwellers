using System.Windows;

namespace CaveDwellers.Core
{
    public interface IPositionable
    {
        Size Size { get; }
        void SetWorldMatrix(WorldMatrix worldMatrix);
    }
}