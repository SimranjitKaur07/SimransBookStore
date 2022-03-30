﻿using SimransBooks.DataAccess.Repository.IRepository;
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

        public void Update(CategoryRepository category)
        {
            // use .NET LINQ to retriveve the first
            throw new NotImplementedException();
        }
    }
}