using System;
using System.Collections.ObjectModel;

namespace TimerManager
{
    class TimerCollection : Collection<Timer>
    {
        public static int CurrentIndex = 1;

        public TimerCollection()
        {
            for (int i = 0; i < 10; i++)
            {
                Add(new Timer(new TimeSpan(0,0,15),CurrentIndex));
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
