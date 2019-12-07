using System;
using System.Collections.ObjectModel;

namespace TimerManager
{
    public class TimerCollection : ObservableCollection<Timer>
    {
      

        public bool DoNotDisturb { get; set; } = false;
        
        public TimerCollection()
        {
            for (int i = 0; i < 10; i++)
            {
                Timer newTimer = new Timer(new TimeSpan(0, 0, 0, 5));
                Add(newTimer);
                newTimer.parrentCollection = this;
               
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
