using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimransBooks.Models;
using SimransBooks.Models.ViewModels;

namespace SimransBookStore.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
     public DbSet<Category>Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
      
    }

    

