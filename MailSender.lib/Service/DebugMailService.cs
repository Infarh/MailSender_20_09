using System.Diagnostics;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Service
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password)
        {
            return  new DebugMailSender(Server, Port, SSL, Login, Password);
        }

        private class DebugMailSender : IMailSender
        {
            private readonly string _Address;
            private readonly int _Port;
            private readonly bool _Ssl;
            private readonly string _Login;
            private readonly string _Password;

            public DebugMailSender(string Address, int Port, bool SSL, string Login, string Password)
            {
                _Address = Address;
                _Port = Port;
                _Ssl = SSL;
                _Login = Login;
                _Password = Password;
            }

            public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
            {
                Debug.WriteLine("Отправка почты через сервер {0}:{1} SSL:{2} (Login:{3}; Pass:{4})",
                    _Address, _Port, _Ssl, _Login, _Password);
                Debug.WriteLine("Сообщение от {0} к {1}:\r\n{2}\r\n{3}",
                    SenderAddress, RecipientAddress, Subject, Body);
            }
        }
    }


}
