using System.Windows;
using CaveDwellers.Core;

namespace CaveDwellers.Positionables
{
    public class Stone : IPositionable
    {
        public Size Size
        {
            get { return new Size(1, 1); }
        }

        public void SetWorldMatrix(WorldMatrix worldMatrix)
        {
        }
    }
}