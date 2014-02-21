using System.Windows.Media;
using CaveDwellers.Core;
using CaveDwellers.Positionables;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellers.UI
{
    public class GamePresenter : IGamePresenter
    {
        private readonly IWantToBeNotifiedOfGameTimeElapsedEvents _view;
        private readonly WorldMatrix _world = new WorldMatrix();
        private readonly GameLoop _gameLoop = new GameLoop();

        public GamePresenter(IWantToBeNotifiedOfGameTimeElapsedEvents view)
        {
            _view = view;
            _gameLoop.Register(_world);
            _gameLoop.Register(_view);

            //dummy implementation of a world - say a level
            _world.Add(0, 0, new Stone());
            _world.Add(10, 0, new Stone());
            _world.Add(20, 0, new Stone());
            _world.Add(30, 0, new Stone());
            _world.Add(40, 0, new Stone());
            _world.Add(50, 0, new Stone());
            _world.Add(60, 0, new Stone());
            _world.Add(70, 0, new Stone());
            _world.Add(80, 0, new Stone());
            _world.Add(90, 0, new Stone());
            _world.Add(100, 0, new Stone());
            _world.Add(110, 0, new Stone());
            _world.Add(120, 0, new Stone());
            _world.Add(130, 0, new Stone());
            _world.Add(140, 0, new Stone());
            _world.Add(150, 0, new Stone());
            _world.Add(160, 0, new Stone());
            _world.Add(170, 0, new Stone());
            _world.Add(180, 0, new Stone());
            _world.Add(190, 0, new Stone());

            _world.Add(0, 10, new Stone());
            _world.Add(190, 10, new Stone());

            _world.Add(0, 20, new Stone());
            _world.Add(190, 20, new Stone());

            _world.Add(0, 30, new Stone());
            _world.Add(190, 30, new Stone());

            _world.Add(0, 40, new Stone());
            _world.Add(190, 40, new Stone());

            _world.Add(00, 50, new Stone());
            _world.Add(190, 50, new Stone());

            _world.Add(0, 60, new Stone());
            _world.Add(190, 60, new Stone());

            _world.Add(0, 70, new Stone());
            _world.Add(190, 70, new Stone());

            _world.Add(0, 80, new Stone());
            _world.Add(190, 80, new Stone());

            _world.Add(0, 90, new Stone());
            _world.Add(190, 90, new Stone());

            _world.Add(0, 100, new Stone());
            _world.Add(190, 100, new Stone());

            _world.Add(0, 110, new Stone());
            _world.Add(190, 110, new Stone());

            _world.Add(0, 120, new Stone());
            _world.Add(190, 120, new Stone());

            _world.Add(0, 130, new Stone());
            _world.Add(190, 130, new Stone());

            _world.Add(00, 140, new Stone());
            _world.Add(190, 140, new Stone());

            _world.Add(0, 150, new Stone());
            _world.Add(190, 150, new Stone());

            _world.Add(0, 160, new Stone());
            _world.Add(190, 160, new Stone());

            _world.Add(0, 170, new Stone());
            _world.Add(190, 170, new Stone());

            _world.Add(0, 180, new Stone());
            _world.Add(190, 180, new Stone());

            _world.Add(0, 190, new Stone());
            _world.Add(10, 190, new Stone());
            _world.Add(20, 190, new Stone());
            _world.Add(30, 190, new Stone());
            _world.Add(40, 190, new Stone());
            _world.Add(50, 190, new Stone());
            _world.Add(60, 190, new Stone());
            _world.Add(70, 190, new Stone());
            _world.Add(80, 190, new Stone());
            _world.Add(90, 190, new Stone());
            _world.Add(100, 190, new Stone());
            _world.Add(110, 190, new Stone());
            _world.Add(120, 190, new Stone());
            _world.Add(130, 190, new Stone());
            _world.Add(140, 190, new Stone());
            _world.Add(150, 190, new Stone());
            _world.Add(160, 190, new Stone());
            _world.Add(170, 190, new Stone());
            _world.Add(180, 190, new Stone());
            _world.Add(190, 190, new Stone());

            _world.Add(50, 50, new Monster(_world));
            _world.Add(25, 50, new Monster(_world));
            _world.Add(50, 25, new Monster(_world));
            _world.Add(75, 50, new Monster(_world));
            _world.Add(50, 75, new Monster(_world));

            _world.Add(150, 50, new Monster(_world));
            _world.Add(125, 50, new Monster(_world));
            _world.Add(150, 25, new Monster(_world));
            _world.Add(175, 50, new Monster(_world));
            _world.Add(150, 75, new Monster(_world));

            _world.Add(50, 150, new Monster(_world));
            _world.Add(25, 150, new Monster(_world));
            _world.Add(50, 125, new Monster(_world));
            _world.Add(75, 150, new Monster(_world));
            _world.Add(50, 175, new Monster(_world));

            _world.Add(150, 150, new Monster(_world));
            _world.Add(125, 150, new Monster(_world));
            _world.Add(150, 125, new Monster(_world));
            _world.Add(175, 150, new Monster(_world));
            _world.Add(150, 175, new Monster(_world));

            //_world.Add(100, 100, new Monster(_world));

            _gameLoop.Start();
        }

        public ImageSource DrawGame()
        {
            var gameDrawing = new GameDrawing();

            foreach (var o in _world.GetObjects())
            {
                gameDrawing.AddImage(o.Key.Sprite, o.Value, o.Key.Size);
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