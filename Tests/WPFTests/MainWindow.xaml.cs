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
                UpdateResultValue(result);
            }){ IsBackground = true }.Start();
        }

        private void UpdateResultValue(string Result)
        {
            if (Dispatcher.CheckAccess())
                ResultText.Text = Result;
            else
                Dispatcher.Invoke(() => UpdateResultValue(Result));
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
