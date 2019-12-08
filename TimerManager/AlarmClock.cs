using System;

namespace TimerManager
{
    public class AlarmClock : Timer
    {
        public new DateTime End { get; set; }
        public AlarmClock(DateTime endDateTime, int soundUriIndex)
        {
            Start = DateTime.Now;
            End = endDateTime;
            Total = End - Start;
            current = Total;
            Index = CurrentIndex;
            CurrentIndex++;
            getSoundUri(soundUriIndex);
            StartLoop();
        }
    }
}
