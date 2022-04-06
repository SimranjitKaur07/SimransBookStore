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
   public class UnitOfWork  :IUnitOfWork //the method to access class
    {
        private readonly ApplicationDbContext _db;             // the using statement


        public UnitOfWork(ApplicationDbContext db)           // Constuctor to use DI and Inject in the repositires
        {
            _db = db;
            Category = new CategoryRepository(_db);
           // SP_Call = new SP_Call(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public ISP_Call SP_Call => throw new NotImplementedException();

        // public ISP_Call SP_Call { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()   // all changes will be saved when the Save method is called at the 'parent' level
        {
            _db.SaveChanges();
        }
    }
}
