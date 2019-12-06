using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TimerManager
{

    [ValueConversion(typeof(bool), typeof(Visibility))]
    class ElapsedToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter.Equals(null)){
                if ((bool)value == true) return Visibility.Collapsed;
                return Visibility.Visible;
            }
            else
            {
                if ((bool)value == true) return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
