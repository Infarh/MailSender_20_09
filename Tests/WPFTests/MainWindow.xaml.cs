using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace WPFTests
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            var to = new MailAddress("shmachilin@gmail.com", "Павел");
            var from = new MailAddress("shmachilin@yandex.ru", "Павел");

            var message = new MailMessage(from, to);

            message.Subject = "Заголовок письма от " + DateTime.Now;
            message.Body = "Текст тестового письма + " + DateTime.Now;

            var client = new SmtpClient("smtp.yandex.ru", 25);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential
            {
                UserName = LoginEdit.Text,
                SecurePassword = PasswordEdit.SecurePassword
            };

            //client.Send(message);

        }
    }
}
