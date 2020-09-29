namespace MailSender.lib.Interfaces
{
    public interface IMailService
    {
        IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password);
    }

    public interface IMailSender
    {
        void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);
    }
}
