﻿using System;
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
            Timer timer = new Timer(new TimeSpan(Days, Hours, Minutes, Seconds));
            timer.parrentCollection = MainWindow.timers;
            MainWindow.timers.Add(timer);
        }
        private void AddAlarmClockWithUserParameters()
        {
            if (!Int32.TryParse(AlarmHours.Text, out Hours))
                Hours = 0;
            if (!Int32.TryParse(AlarmMinutes.Text, out Minutes))
                Minutes = 0;
            if (!Int32.TryParse(AlarmSeconds.Text, out Seconds))
                Seconds = 0;
           //TODO continue later
        }
    }
}