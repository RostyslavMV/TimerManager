using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace TimerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimerCollection timers = new TimerCollection();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Tick += TimerTick;
            dispatcherTimer.Start();
            TimerList.ItemsSource = timers;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timers.Update();
            foreach (Timer timer in timers.ToList())
            {
                if (timer.Elapsed && !timer.DeleteButtonIsShowed)
                {
                    timer.DeleteButtonIsShowed = true;
                    timer.IsVisibleFromElapsed = true;
                    if (!timers.DoNotDisturb)
                        Task.Run(() =>
                        {
                            MediaPlayer mediaPlayer = new MediaPlayer();
                            mediaPlayer.Open(new Uri("../../Sounds/alarm-beep.mp3", UriKind.RelativeOrAbsolute));
                            mediaPlayer.Volume = 1;
                            mediaPlayer.Play();
                            var result = MessageBox.Show("Timer " + timer.Index + " elapsed", "Timer manager", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (result == MessageBoxResult.OK)
                                mediaPlayer.Stop();
                        });
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            timers.Remove(TimerList.SelectedItem as Timer);
            //TODO fix
        }

        private void DoNotDisturbButton_Click(object sender, RoutedEventArgs e)
        {
            if (timers.DoNotDisturb) timers.DoNotDisturb = false;
            else timers.DoNotDisturb = true;
        }

        private void OpenTimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
