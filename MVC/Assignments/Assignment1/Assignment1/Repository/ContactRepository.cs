using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Assignment1.Models;

namespace Assignment1.Repository
{
    public class ContactRepository : IContactRepository
    {
        ContactContext db;
        public ContactRepository()
        {
            db = new ContactContext();
        }
        public Task CreateAsync(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(long Id)
        {
            var contact = db.Contacts.Find(Id);
            db.Contacts.Remove(contact);
            db.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return (await db.Contacts.ToListAsync());
        }
    }
}
