using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimerManager
{
    public class Timer : INotifyPropertyChanged
    {
        #region Private Properties
        #endregion

        #region Public Properties

        public int Index { get; set; }

        public DateTime Start { get; set; }

        public TimeSpan Total { get; set; }

        private TimeSpan current;

        public event PropertyChangedEventHandler PropertyChanged;

        public TimeSpan Value { get; set; }
        public TimeSpan Current
        {
            get => current;
            set
            {
                current = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Current"));
            }
        }
        public TimeSpan Loop => DateTime.Now - Start;

        public TimeSpan End = new TimeSpan(0, 0, 0);

        public bool Elapsed => Current <= End;

        private bool elapsed;
        public bool IsVisibleFromElapsed
        {
            get => Elapsed;
            set
            {
                elapsed = Elapsed;
                PropertyChanged(this, new PropertyChangedEventArgs("IsVisibleFromElapsed"));
            }
        }

        public bool IsTicking { get; set; } = false;

        #endregion

        #region Constructors


        /// <summary>
        /// Constructor with time string as parameter
        /// </summary>
        /// <param name="Time"></param>
        public Timer(TimeSpan total, int index)
        {
            Total = total;
            Start = DateTime.Now;
            current = Total;
            Index = index;
        }

        #endregion

        #region Functions

        public void Pause()
        {
            if (IsTicking)
            {
                Total -= Loop;
                IsTicking = false;
            }
        }

        public void StartLoop()
        {
            if (!IsTicking)
            {
                Start = DateTime.Now;
                IsTicking = true;
            }
        }

        #endregion

        #region Helpers

        private enum TimeType
        {
            Hours,
            Minutes,
            Seconds
        }

        public void Update()
        {
            if (IsTicking && !Elapsed)
            {
                if (Total > Loop)
                    Current = Total - Loop;
                else
                    Current = new TimeSpan(0, 0, 0);
            }
               
        }

        public TimeSpan StringToTimeSpan(string Time)
        {
            string[] PartsOfTime = Time.Split(':');
            int Days = 0, Hours = 0, Minutes = 0, Seconds = 0;
            TimeType tt = TimeType.Hours;
            foreach (string Part in PartsOfTime)
            {
                int AddValue = 0;
                if (Part.EndsWith("y"))
                {
                    Int32.TryParse(Part.Substring(0, Part.Length - 1), out AddValue);
                    Days += AddValue * 365;
                }
                else if (Part.EndsWith("d"))
                {
                    Int32.TryParse(Part.Substring(0, Part.Length - 1), out AddValue);
                    Days += AddValue;
                }
                else if (tt == TimeType.Hours)
                {
                    Int32.TryParse(Part.Substring(0, Part.Length), out AddValue);
                    Hours += AddValue;
                    tt = TimeType.Minutes;
                }
                else if (tt == TimeType.Minutes)
                {
                    Int32.TryParse(Part.Substring(0, Part.Length), out AddValue);
                    Minutes += AddValue;
                    tt = TimeType.Seconds;
                }
                else if (tt == TimeType.Seconds)
                {
                    Int32.TryParse(Part.Substring(0, Part.Length), out AddValue);
                    Seconds += AddValue;
                    tt = TimeType.Seconds;
                }
            }
            return new TimeSpan(Days, Hours, Minutes, Seconds);
        }
        #endregion

    }
}
