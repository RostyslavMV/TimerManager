using System;
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
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class TimerControl : UserControl
    {
        Timer timer => DataContext as Timer;
        public TimerControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IsVisibleFromElapsedProperty =
        DependencyProperty.Register("IsVisibleFromElapsed", typeof(bool),
        typeof(TimerControl), new FrameworkPropertyMetadata(false));

        public bool IsVisibleFromElapsed { get { return timer.Elapsed; } }

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
            ((ListBox)this.Parent).Items.Remove(this);
        }
    }
}
