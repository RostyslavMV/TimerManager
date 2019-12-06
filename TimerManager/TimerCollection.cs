using System;
using System.Collections.ObjectModel;

namespace TimerManager
{
    class TimerCollection : ObservableCollection<Timer>
    {
        public static int CurrentIndex = 1;

        public bool DoNotDisturb { get; set; } = false;
        
        public TimerCollection()
        {
            for (int i = 0; i < 10; i++)
            {
                Timer newTimer = new Timer(new TimeSpan(0, 0, 0, 5), CurrentIndex);
                Add(newTimer);
                newTimer.parrentCollection = this;
                CurrentIndex++;
            }
        }

        internal void Update()
        {
            foreach(Timer t in this)
            {
                t.Update();
            }
        }
    }
}
