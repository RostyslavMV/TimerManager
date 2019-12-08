using System.Windows.Controls;

namespace TimerManager
{
    /// <summary>
    /// Interaction logic for TImerViewControl.xaml
    /// </summary>
    public partial class TimerViewControl : UserControl
    {
        Timer timer => DataContext as Timer;

        public TimerViewControl()
        {
            InitializeComponent();
        }
    }
}
