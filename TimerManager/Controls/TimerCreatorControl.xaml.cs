using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimerManager
{
    /// <summary>
    /// Interaction logic for TimerCreator.xaml
    /// </summary>
    public partial class TimerCreatorControl : UserControl
    {
        int Days, Hours, Minutes, Seconds;
        Uri soundUri1 = new Uri("../../Sounds/alarm-beep1.mp3", UriKind.RelativeOrAbsolute);
        Uri soundUri2 = new Uri("../../Sounds/alarm-beep2.mp3", UriKind.RelativeOrAbsolute);
        Uri soundUri3 = new Uri("../../Sounds/alarm-beep3.mp3", UriKind.RelativeOrAbsolute);
        public TimerCreatorControl()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Tabs.SelectedIndex == 0)
                AddTimerWithUserParameters();
            else if (Tabs.SelectedIndex == 1)
                AddAlarmClockWithUserParameters();
        }

        private void AddTimerWithUserParameters()
        {
            if (!Int32.TryParse(TimerDays.Text, out Days))
                Days = 0;
            if (!Int32.TryParse(TimerHours.Text, out Hours))
                Hours = 0;
            if (!Int32.TryParse(TimerMinutes.Text, out Minutes))
                Minutes = 0;
            if (!Int32.TryParse(TimerSeconds.Text, out Seconds))
                Seconds = 0;
            if (Days != 0 || Hours != 0 || Minutes != 0 || Seconds != 0)
            {
                Timer timer = new Timer(new TimeSpan(Days, Hours, Minutes, Seconds), Sound.SelectedIndex);
                timer.parrentCollection = MainWindow.timers;
                MainWindow.timers.Add(timer);
                MainWindow.ListBox.SelectedItem = timer;
            }
        }
        private void AddAlarmClockWithUserParameters()
        {
            DateTime dateTime;
            if (!Int32.TryParse(AlarmHours.Text, out Hours))
                Hours = 0;
            if (!Int32.TryParse(AlarmMinutes.Text, out Minutes))
                Minutes = 0;
            if (!Int32.TryParse(AlarmSeconds.Text, out Seconds))
                Seconds = 0;
            if (AlarmDate.SelectedDate != null)
            {
                dateTime = AlarmDate.SelectedDate.Value;
                dateTime = dateTime.Add(new TimeSpan(Hours, Minutes, Seconds));
                if (dateTime.CompareTo(DateTime.Now) > 0)
                {
                    AlarmClock alarmClock = new AlarmClock(dateTime, Sound.SelectedIndex);
                    alarmClock.parrentCollection = MainWindow.timers;
                    MainWindow.timers.Add(alarmClock);
                    MainWindow.ListBox.SelectedItem = alarmClock;
                }
            }
        }
    }
}
