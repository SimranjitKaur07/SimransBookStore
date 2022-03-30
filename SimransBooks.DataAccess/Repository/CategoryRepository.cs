using SimransBooks.DataAccess.Repository.IRepository;
using SimransBooks.Models;
using SimransBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimransBooks.DataAccess.Repository
{
   public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public object Id { get; private set; }
        public object Name { get; private set; }

        public void Update(CategoryRepository category)
        {
            // use .NET LINQ to retriveve the first or default category object.
            // than pass the id as a generic entity which matches the category Id
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (objFromDb != null) // save changes if not null
            {
                objFromDb.Name = category.Name;
                _db.SaveChanges();
            }
            throw new NotImplementedException();
        }
    }
}
