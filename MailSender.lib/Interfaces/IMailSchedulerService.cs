using System;
using System.Collections.Generic;
using MailSender.lib.Models;

namespace MailSender.lib.Interfaces
{
    public interface IMailSchedulerService
    {
        void Start();

        void Stop();

        void AddTask(DateTime Time, Sender Sender, IEnumerable<Recipient> Recipients, Server Server, Message Message);
    }
}
