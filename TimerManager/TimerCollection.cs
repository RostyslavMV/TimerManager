using System.Collections.ObjectModel;

namespace TimerManager
{
    public class TimerCollection : ObservableCollection<Timer>
    {


        public bool DoNotDisturb { get; set; } = false;

        public TimerCollection()
        {

        }

        internal void Update()
        {
            foreach (Timer t in this)
            {
                t.Update();
            }
        }
    }
}
