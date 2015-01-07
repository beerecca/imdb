using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
	public class BaseRepository<T> where T : BaseModel
	{
		protected ImdbContext db = new ImdbContext();

		public T GetById(int id)
		{
			return db.Set<T>().FirstOrDefault(x => x.Id == id);
		}
	}
}