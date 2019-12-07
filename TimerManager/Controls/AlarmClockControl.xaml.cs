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
