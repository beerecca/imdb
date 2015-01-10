using System.Collections.Generic;
using System.Linq;
using IMDB.Models;

namespace IMDB.Repositories
{
    public class BaseRepository<T> where T : class, IModel
    {
        protected ImdbContext db = new ImdbContext();

        public List<T> GetById(int id)
        {
            return db.Set<T>().Where(r => r.Id == id).ToList();

        }
    }
}