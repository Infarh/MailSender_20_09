using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;
using MailSender.lib.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace MailSender.Data.Stores.InDB
{
    class StoreInDB<T> : IStore<T> where T : Entity
    {
        private readonly MailSenderDB _db;
        private readonly DbSet<T> _Set;

        public StoreInDB(MailSenderDB db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public IEnumerable<T> GetAll() => _Set.ToArray();

        public T GetById(int Id) => _Set.SingleOrDefault(r => r.Id == Id);

        public T Add(T Item)
        {
            _db.Entry(Item).State = EntityState.Added;
            //_db.Recipients.Add(Item);
            _db.SaveChanges();
            return Item;
        }

        public void Update(T Item)
        {
            _db.Entry(Item).State = EntityState.Modified;
            //_db.Recipients.Update(Item);
            _db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var item = GetById(Id);
            if (item is null) return;

            //_db.Recipients.Remove(item);
            _db.Entry(item).State = EntityState.Deleted;
            _db.SaveChanges();
        }
    }
}
