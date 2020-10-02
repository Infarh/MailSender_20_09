using System;
using MailSender.lib.Models.Base;

namespace MailSender.lib.Models
{
    public class Recipient : Person
    {
        public override string Name
        {
            get => base.Name;
            set
            {
                if(value is null)
                    throw new ArgumentNullException(nameof(value));

                if(value == "")
                    throw new ArgumentException("Имя не может быть пустой строкой", nameof(value));

                if (value == "QWE")
                    throw new ArgumentException("Запрещено вводить QWE!", nameof(value));


                base.Name = value;
            }
        }
    }
}
