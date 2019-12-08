using System.Windows;
using System.Windows.Controls;

namespace TimerManager
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class TimerControl : UserControl
    {
        Timer timer => DataContext as Timer;
        public TimerControl()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.StartLoop();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Pause();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            timer.mediaPlayer.Stop();
            timer.parrentCollection.Remove(timer);
        }
    }
}
