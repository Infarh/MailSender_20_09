using System;
using System.Collections.Generic;
using System.Text;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        #region SendMessagesCount : int - Число отправленных сообщений

        /// <summary>Число отправленных сообщений</summary>
        private int _SendMessagesCount;

        /// <summary>Число отправленных сообщений</summary>
        public int SendMessagesCount { get => _SendMessagesCount; private set => Set(ref _SendMessagesCount, value); }

        #endregion

        public void MessageSended() => SendMessagesCount++;
    }
}
