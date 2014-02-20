using System.Windows;
using CaveDwellers.Core;
using CaveDwellers.Resources;

namespace CaveDwellers.Positionables
{
    public class Stone : IPositionable
    {
        public virtual Size Size
        {
            get { return new Size(10, 10); }
        }

        public void SetWorldMatrix(WorldMatrix worldMatrix)
        {
        }

        public ImageName Sprite
        {
            get { return Images.Stone01; }
        }
    }
}