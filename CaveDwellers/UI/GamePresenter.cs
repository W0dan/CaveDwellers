using System.Windows.Media;
using CaveDwellers.Core;
using CaveDwellers.Core.Movement;
using CaveDwellers.Core.TimeManagement;
using CaveDwellers.Positionables;
using CaveDwellers.Positionables.Monsters;
using CaveDwellers.Utility;

namespace CaveDwellers.UI
{
    public class GamePresenter : IGamePresenter
    {
        private readonly IWantToBeNotifiedOfGameTimeElapsedEvents _view;
        private readonly WorldMatrix _world = new WorldMatrix();
        private readonly GameLoop _gameLoop = new GameLoop();
        private readonly GoodGuy _goodGuy;

        public GamePresenter(IWantToBeNotifiedOfGameTimeElapsedEvents view)
        {
            _view = view;
            _gameLoop.Register(_world);
            _gameLoop.Register(_view);
            _goodGuy = new GoodGuy(_world);

            CreateDummyLevel(_world, _goodGuy);

            _gameLoop.Register(_goodGuy);
            _gameLoop.Start();
        }

        private void CreateDummyLevel(IWorldMatrix world, GoodGuy goodGuy)
        {
            //++ dummy implementation of a world - say a level
            //todo: make abstraction of a level
            for (var i = 0; i < 200; i += 10)
            {
                world.Add(i, 0, new Stone());
                world.Add(i, 190, new Stone());
            }

            for (var i = 10; i < 190; i += 10)
            {
                world.Add(0, i, new Stone());
                world.Add(190, i, new Stone());
            }

            IRnd randomizer = new Rnd(200, 200);
            world.Add(50, 25, new Monster(world, randomizer));
            world.Add(150, 25, new Monster(world, randomizer));
            world.Add(50, 125, new Monster(world, randomizer));
            world.Add(150, 125, new Monster(world, randomizer));

            world.Add(100, 100, goodGuy);
            //-- dummy level
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