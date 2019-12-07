using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerManager
{
    public class AlarmClock : Timer
    {
        public new DateTime End { get; set; }
        public AlarmClock(DateTime endDateTime,Uri soundUri)
        {
            Start = DateTime.Now;
            End = endDateTime;
            Total = End - Start;
            current = Total;
            Index = CurrentIndex;
            CurrentIndex++;
            SoundUri = soundUri;
            StartLoop();
        }
    }
}
