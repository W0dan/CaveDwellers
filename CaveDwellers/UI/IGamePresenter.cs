using System.Windows.Media;
using CaveDwellers.Core;

namespace CaveDwellers.UI
{
    public interface IGamePresenter
    {
        ImageSource DrawGame();
        bool Level_is_finished { get; }
        bool Game_is_over { get; }
        void Fire(Direction direction);
        void Move(Direction direction);
        void StopMoving();
    }
}