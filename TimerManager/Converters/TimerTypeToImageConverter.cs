﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TimerManager
{

    [ValueConversion(typeof(object), typeof(BitmapImage))]
    class TimerTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
                return null;
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            if (value is AlarmClock)
            {
                bmp.UriSource = new Uri("pack://application:,,,/Images/alarm-clock.png");
                bmp.EndInit();
                return bmp;
            }
            bmp.UriSource = new Uri("pack://application:,,,/Images/timer.png");
            bmp.EndInit();
            return bmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
