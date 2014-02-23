namespace CaveDwellers.Core.TimeManagement
{
    public interface IWantToBeNotifiedOfGameTimeElapsedEvents
    {
        void Notify(GameTime gameTime);
    }
}