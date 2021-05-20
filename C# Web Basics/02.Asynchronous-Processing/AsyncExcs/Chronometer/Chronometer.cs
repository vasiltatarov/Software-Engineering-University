using System.Collections.Generic;
using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.Laps = new List<string>();
        }

        public string GetTime 
            => $"{this.stopwatch.Elapsed.Minutes:D2}:{this.stopwatch.Elapsed.Seconds:D2}:{this.stopwatch.Elapsed.Milliseconds:D4}";

        public List<string> Laps { get; }

        public void Start()
            => this.stopwatch.Start();

        public void Stop()
        {
            this.stopwatch.Stop();
        }

        public string Lap()
        {
            var currentTime = this.GetTime;
            this.Laps.Add(currentTime);
            return currentTime;
        }

        public void Reset()
        {
            this.Stop();
            this.stopwatch.Reset();
            this.Laps.Clear();
        }
    }
}
