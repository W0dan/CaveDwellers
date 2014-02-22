using System;
using System.Windows.Media;
using CaveDwellers.Core;
using CaveDwellers.Positionables;
using CaveDwellers.Positionables.Monsters;

namespace CaveDwellers.UI
{
    public class GamePresenter : IGamePresenter
    {
        private readonly IRnd _randomizer = new Rnd();
        private readonly IWantToBeNotifiedOfGameTimeElapsedEvents _view;
        private readonly WorldMatrix _world = new WorldMatrix();
        private readonly GameLoop _gameLoop = new GameLoop();
        private readonly GoodGuy _goodGuy;

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

            _world.Add(50, 25, new Monster(_world, _randomizer));
            _world.Add(150, 25, new Monster(_world, _randomizer));
            _world.Add(50, 125, new Monster(_world, _randomizer));
            _world.Add(150, 125, new Monster(_world, _randomizer));

            _goodGuy = new GoodGuy(_world);
            _world.Add(100, 100, _goodGuy);
            _gameLoop.Register(_goodGuy);

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
            _goodGuy.StartMoving(direction);
        }

        public void StopMoving()
        {
            _goodGuy.StopMoving();
        }
    }
}