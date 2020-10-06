using System.Threading;
using System.Windows;

namespace WPFTests
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void ComputeResultButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new Thread(() =>
            {
                var result = GetResultHard();
                Application.Current.Dispatcher.Invoke(() => ResultText.Text = result);
            }){ IsBackground = true }.Start();
        }

        private string GetResultHard()
        {
            for (var i = 0; i < 500; i++)
            {
                Thread.Sleep(10);
            }

            return "Hello World";
        }
    }
}
