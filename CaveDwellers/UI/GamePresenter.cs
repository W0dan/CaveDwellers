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
            for (var i = 0; i < 200; i += 10)
            {
                _world.Add(i, 0, new Stone());
                _world.Add(i, 190, new Stone());
            }

            for (var i = 10; i < 190; i += 10)
            {
                _world.Add(0, i, new Stone());
                _world.Add(190, i, new Stone());
            }

            //_world.Add(50, 50, new Monster(_world));
            //_world.Add(25, 50, new Monster(_world));
            _world.Add(50, 25, new Monster(_world));
            //_world.Add(75, 50, new Monster(_world));
            //_world.Add(50, 75, new Monster(_world));

            //_world.Add(150, 50, new Monster(_world));
            //_world.Add(125, 50, new Monster(_world));
            _world.Add(150, 25, new Monster(_world));
            //_world.Add(175, 50, new Monster(_world));
            //_world.Add(150, 75, new Monster(_world));

            //_world.Add(50, 150, new Monster(_world));
            //_world.Add(25, 150, new Monster(_world));
            _world.Add(50, 125, new Monster(_world));
            //_world.Add(75, 150, new Monster(_world));
            //_world.Add(50, 175, new Monster(_world));

            //_world.Add(150, 150, new Monster(_world));
            //_world.Add(125, 150, new Monster(_world));
            _world.Add(150, 125, new Monster(_world));
            //_world.Add(175, 150, new Monster(_world));
            //_world.Add(150, 175, new Monster(_world));

            _world.Add(100, 100, new GoodGuy(_world));

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
            _world.GoodGuy.StartMoving(direction);
        }

        public void StopMoving()
        {
            _world.GoodGuy.StopMoving();
        }
    }
}