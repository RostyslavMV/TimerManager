using System;
using System.Collections.ObjectModel;
using System.Windows;
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
            dispatcherTimer.Interval = new TimeSpan(0,0,0,0,100);
            dispatcherTimer.Tick += TimerTick;
            dispatcherTimer.Start();
            list.ItemsSource = timers;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timers.Update();
        }
    }
}
