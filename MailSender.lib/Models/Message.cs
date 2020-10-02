using MailSender.lib.Models.Base;

namespace MailSender.lib.Models
{
    public class Message : Entity
    {
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
