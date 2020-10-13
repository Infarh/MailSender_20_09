using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using Microsoft.EntityFrameworkCore;

namespace MailSender.Data.Stores.InDB
{
    class RecipientsStoreInDB : IStore<Recipient>
    {
        private readonly MailSenderDB _db;

        public RecipientsStoreInDB(MailSenderDB db) => _db = db;

        public IEnumerable<Recipient> GetAll() => _db.Recipients.ToArray();

        //public Recipient GetById(int Id) => _db.Recipients.Find(Id);
        //public Recipient GetById(int Id) => _db.Recipients.FirstOrDefault(r => r.Id == Id);
        public Recipient GetById(int Id) => _db.Recipients.SingleOrDefault(r => r.Id == Id);

        public Recipient Add(Recipient Item)
        {
            _db.Entry(Item).State = EntityState.Added;
            //_db.Recipients.Add(Item);
            _db.SaveChanges();
            return Item;
        }

        public void Update(Recipient Item)
        {
            _db.Entry(Item).State = EntityState.Modified;
            //_db.Recipients.Update(Item);
            _db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var item = GetById(Id);
            if(item is null) return;

            //_db.Recipients.Remove(item);
            _db.Entry(item).State = EntityState.Deleted;
            _db.SaveChanges();
        }
    }
}
