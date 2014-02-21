using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace CaveDwellers.Core
{
    public class GameLoop
    {
        private bool _timerRunning;

        private readonly DispatcherTimer _timer;
        private readonly List<IWantToBeNotifiedOfGameTimeElapsedEvents> _listeners;
        private DateTime _previousElapsedTime;

        public GameLoop()
        {
            _listeners = new List<IWantToBeNotifiedOfGameTimeElapsedEvents>();
            _timer = new DispatcherTimer{Interval = new TimeSpan(0,0,0,0,20)};
            _timer.Tick += _timer_Tick;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            if (!_timerRunning)
                return;

            _timer.Stop();

            var now = DateTime.Now;
            var milliseconds = now.Subtract(_previousElapsedTime).TotalMilliseconds;

            _listeners.ForEach(l => l.Notify(new GameTime(now, (int)milliseconds)));

            _previousElapsedTime = now;

            if (_timerRunning)
                _timer.Start();
        }

        public void Register(IWantToBeNotifiedOfGameTimeElapsedEvents registree)
        {
            _listeners.Add(registree);
        }

        public void Start()
        {
            _timer.Start();
            _timerRunning = true;
        }

        public void Stop()
        {
            _timer.Stop();
            _timerRunning = false;
        }
    }
}