using System.Windows.Media;
using CaveDwellers.Core;
using CaveDwellers.Positionables;

namespace CaveDwellers.UI
{
    public class GamePresenter : IGamePresenter
    {
        private readonly WorldMatrix _world = new WorldMatrix();

        public GamePresenter()
        {
            //dummy implementation of a world - say a level
            _world.Add(0, 0, new Stone());
            _world.Add(1, 0, new Stone());
            _world.Add(2, 0, new Stone());
            _world.Add(3, 0, new Stone());
            _world.Add(4, 0, new Stone());

            _world.Add(0, 1, new Stone());
            _world.Add(4, 1, new Stone());

            _world.Add(0, 2, new Stone());
            _world.Add(4, 2, new Stone());

            _world.Add(0, 3, new Stone());
            _world.Add(4, 3, new Stone());

            _world.Add(0, 4, new Stone());
            _world.Add(1, 4, new Stone());
            _world.Add(2, 4, new Stone());
            _world.Add(3, 4, new Stone());
            _world.Add(4, 4, new Stone());
        }

        public ImageSource DrawGame()
        {
            var gameDrawing = new GameDrawing();

            foreach (var o in _world.GetObjects())
            {
                gameDrawing.AddImage(o.Value.Sprite, o.Key, o.Value.Size);
            }

            return gameDrawing.GetImage();
        }

        public bool Level_is_finished
        {
            get { return false; }
        }

        public bool Game_is_over
        {
            get { return false; }
        }

        public void Fire(Direction direction)
        {
        }

        public void Move(Direction direction)
        {
        }
    }
}