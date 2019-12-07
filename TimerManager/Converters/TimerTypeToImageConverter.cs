using System;
using System.Globalization;
using System.Windows.Data;

namespace TimerManager
{

    [ValueConversion(typeof(object), typeof(string))]
    class TimerTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Timer) return "/Images/timer.png";
            return "/Images/alarm-clock.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
