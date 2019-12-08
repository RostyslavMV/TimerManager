using System.Windows;
using System.Windows.Controls;

namespace TimerManager
{
    /// <summary>
    /// Interaction logic for TimerListControl.xaml
    /// </summary>
    public partial class TimerListControl : ListBox
    {
        public TimerListControl()
        {
            InitializeComponent();
        }
    }

    public class TimerTypeTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            Timer timer = item as Timer;
            if (timer is AlarmClock)
            {
                return element.FindResource("AlarmClockTemplate") as DataTemplate;
            }
            else
            {
                return element.FindResource("TimerTemplate") as DataTemplate;
            }
        }
    }
}
