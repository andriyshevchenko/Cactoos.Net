using Cactoos;
using System;
using System.Diagnostics;

namespace Cactoos.Scalar
{
    public class Elapsed : IScalar<TimeSpan>
    {
        private Action _action;
        private Stopwatch _clock;

        public Elapsed(Action run)
        {
            _action = run;
        }

        public TimeSpan Value()
        {
            _clock = new Stopwatch();
            _clock.Start();
            _action();
            _clock.Stop();
            return _clock.Elapsed;
        }
    } 
}