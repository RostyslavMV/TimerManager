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
        public static TimerCollection timers = new TimerCollection();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public static TimerListControl ListBox;

        public MainWindow()
        {
            InitializeComponent();
            TimerCreator.Visibility = Visibility.Collapsed;
            TimerView.Visibility = Visibility.Collapsed;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Tick += TimerTick;
            dispatcherTimer.Start();
            TimerList.ItemsSource = timers;
            ListBox = TimerList;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timers.Update();
            foreach (Timer timer in timers.ToList())
            {
                if (timer.Elapsed && !timer.DeleteButtonIsShowed)
                {
                    TimerList.ScrollIntoView(timer);
                    timer.DeleteButtonIsShowed = true;
                    timer.IsVisibleFromElapsed = true;
                    if (!timers.DoNotDisturb)
                    {
                        timer.mediaPlayer.Open(timer.SoundUri);
                        timer.mediaPlayer.Volume = 1;
                        timer.mediaPlayer.Play();
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Timer timer = TimerList.SelectedItem as Timer;
            if (timer != null)
            {
                timer.mediaPlayer.Stop();
                timers.Remove(timer);
            }
        }

        private void DoNotDisturbButton_Click(object sender, RoutedEventArgs e)
        {
            if (timers.DoNotDisturb) timers.DoNotDisturb = false;
            else timers.DoNotDisturb = true;
        }

        private void OpenTimer_Click(object sender, RoutedEventArgs e)
        {
            TimerCreator.Visibility = Visibility.Collapsed;
            TimerView.Visibility = Visibility.Visible;
        }

        private void AddTimerButton_Click(object sender, RoutedEventArgs e)
        {
            TimerView.Visibility = Visibility.Collapsed;
            TimerCreator.Visibility = Visibility.Visible;
        }

        private void TimerList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TimerCreator.Visibility = Visibility.Collapsed;
            TimerView.Visibility = Visibility.Visible;
        }

    }
}
