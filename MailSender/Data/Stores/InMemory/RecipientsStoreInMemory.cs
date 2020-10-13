using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;

namespace MailSender.Data.Stores.InMemory
{
    class RecipientsStoreInMemory : IStore<Recipient>
    {
        public IEnumerable<Recipient> GetAll() => TestData.Recipients;

        public Recipient GetById(int Id) => GetAll().FirstOrDefault(r => r.Id == Id);

        public Recipient Add(Recipient Item)
        {
            if (TestData.Recipients.Contains(Item)) return Item;

            Item.Id = TestData.Recipients.DefaultIfEmpty().Max(r => r.Id) + 1;
            TestData.Recipients.Add(Item);
            return Item;
        }

        public void Update(Recipient Item) { }

        public void Delete(int Id)
        {
            var item = GetById(Id);
            if(item is null) return;
            TestData.Recipients.Remove(item);
        }
    }
}
