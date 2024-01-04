using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : DatabaseRepo, ICrud<Token, int, bool>
    {
        public bool Add(Token data)
        {
            database.Tokens.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Tokens.Remove(Get(id));
            return database.SaveChanges() > 0;
        }

        public Token Get(int id)
        {
            return database.Tokens.Find(id);
        }

        public List<Token> GetAll()
        {
            return database.Tokens.ToList();
        }

        public bool Update(Token data)
        {
            var record = Get(data.token_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
