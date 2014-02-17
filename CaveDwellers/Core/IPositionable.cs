using System.Windows;
using CaveDwellers.Resources;

namespace CaveDwellers.Core
{
    public interface IPositionable
    {
        Size Size { get; }
        ImageName Sprite { get; }
    }
}