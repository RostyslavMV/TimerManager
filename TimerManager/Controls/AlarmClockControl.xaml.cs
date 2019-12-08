using System.Windows;
using System.Windows.Controls;

namespace TimerManager
{
    /// <summary>
    /// Interaction logic for AlarmClockControl.xaml
    /// </summary>
    public partial class AlarmClockControl : UserControl
    {
        AlarmClock alarmClock => DataContext as AlarmClock;

        public AlarmClockControl()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            alarmClock.mediaPlayer.Stop();
            alarmClock.parrentCollection.Remove(alarmClock);
        }
    }
}
