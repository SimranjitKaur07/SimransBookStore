using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimransBooks.Models;

namespace SimransBooks.DataAccess.Repository.IRepository
{
   public interface ICategoryRepository : IRepository<Category>
    {
        void Update(CategoryRepository category);
    }
}
