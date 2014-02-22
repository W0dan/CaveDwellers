using System.Windows;
using System.Windows.Input;
using CaveDwellers.Core;
using CaveDwellers.UI;

namespace CaveDwellers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWantToBeNotifiedOfGameTimeElapsedEvents
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private IGamePresenter _gamePresenter;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _gamePresenter = new GamePresenter(this);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_gamePresenter.Level_is_finished || _gamePresenter.Game_is_over)
                return;

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.Up: 
                        _gamePresenter.Fire(Direction.Up);
                        break;
                    case Key.Down:
                        _gamePresenter.Fire(Direction.Down);
                        break;
                    case Key.Left:
                        _gamePresenter.Fire(Direction.Left);
                        break;
                    case Key.Right:
                        _gamePresenter.Fire(Direction.Right);
                        break;
                    default:
                        return;
                }
            }
            else
            {
                switch (e.Key)
                {
                    case Key.Up: 
                        _gamePresenter.Move(Direction.Up);
                        break;
                    case Key.Down:
                        _gamePresenter.Move(Direction.Down);
                        break;
                    case Key.Left:
                        _gamePresenter.Move(Direction.Left);
                        break;
                    case Key.Right:
                        _gamePresenter.Move(Direction.Right);
                        break;
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            _gamePresenter.StopMoving();
        }

        public void Notify(GameTime gameTime)
        {
            GameCanvas.Source = _gamePresenter.DrawGame();
        }
    }
}