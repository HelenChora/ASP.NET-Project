using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookRepo : DatabaseRepo, ICrud<Book, int, bool>
    {
        public bool Add(Book data)
        {
            database.Books.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Books.Remove(Get(id));
            return database.SaveChanges() > 0;
        }

        public Book Get(int id)
        {
            return database.Books.Find(id);
        }

        public List<Book> GetAll()
        {
            return database.Books.ToList();
        }

        public bool Update(Book data)
        {
            var record = Get(data.book_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}