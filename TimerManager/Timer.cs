using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TimerManager
{
    public class Timer : INotifyPropertyChanged
    {
        #region Private Properties

        protected TimeSpan current;

        private Uri soundUri1 = new Uri("../../Sounds/alarm-beep1.mp3", UriKind.RelativeOrAbsolute);
        private Uri soundUri2 = new Uri("../../Sounds/alarm-beep2.mp3", UriKind.RelativeOrAbsolute);
        private Uri soundUri3 = new Uri("../../Sounds/alarm-beep3.mp3", UriKind.RelativeOrAbsolute);

        #endregion

        #region Public Properties

        public MediaPlayer mediaPlayer = new MediaPlayer();
        public Uri SoundUri { get; set; }

        public int SoundBeepIndex { get; set; }

        public static int CurrentIndex = 1;

        public Collection<Timer> parrentCollection;
        public bool DeleteButtonIsShowed { get; set; } = false;

        public int Index { get; set; }

        public DateTime Start { get; set; }

        public TimeSpan Total { get; set; }

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
        public Timer(TimeSpan total, int soundUriIndex)
        {
            Total = total;
            Start = DateTime.Now;
            current = Total;
            Index = CurrentIndex;
            CurrentIndex++;
            getSoundUri(soundUriIndex);
        }

        public Timer()
        {
            Total = default;
            Start = DateTime.Now;
            current = Total;
            Index = CurrentIndex;
            SoundUri = new Uri("../../Sounds/alarm-beep1.mp3", UriKind.RelativeOrAbsolute);
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
        protected void getSoundUri(int index)
        {
            switch (index)
            {
                case 0:
                    SoundUri = soundUri1;
                    SoundBeepIndex = index + 1;
                    break;
                case 1:
                    SoundUri = soundUri2;
                    SoundBeepIndex = index + 1;
                    break;
                case 2:
                    SoundUri = soundUri3;
                    SoundBeepIndex = index + 1;
                    break;
                default:
                    SoundUri = soundUri1;
                    SoundBeepIndex = index + 1;
                    break;
            }
        }
        #endregion

    }
}
