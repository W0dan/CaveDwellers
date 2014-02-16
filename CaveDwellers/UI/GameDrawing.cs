using System.Windows;
using System.Windows.Media;
using CaveDwellers.Resources;

namespace CaveDwellers.UI
{
    public class GameDrawing
    {
        readonly DrawingGroup _gameDrawing = new DrawingGroup();

        public void AddImage(ImageName imageName, Point position, Size size)
        {
            _gameDrawing.Children.Add(ResourceProvider.GetImage(imageName, new Rect(position.X, position.Y, size.Width, size.Height)));
        }

        public DrawingImage GetImage()
        {
            return new DrawingImage(_gameDrawing);
        }
    }
}