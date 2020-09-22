using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var to = new MailAddress("shmachilin@gmail.com", "Павел");
            var from = new MailAddress("shmachilin@yandex.ru", "Павел");

            var message = new MailMessage(from, to);
            //var msg = new MailAddress("user@server.ru", "qwe@ASD.ru");

            message.Subject = "Заголовок письма от " + DateTime.Now;
            message.Body = "Текст тестового письма + " + DateTime.Now;

            var client = new SmtpClient("smtp.yandex.ru", 587);

            client.Credentials = new NetworkCredential
            {
                UserName = "user_name",
                Password = "PassWord!"
            };

            client.Send(message);

            Console.WriteLine("Hello World!");
        }
    }
}
