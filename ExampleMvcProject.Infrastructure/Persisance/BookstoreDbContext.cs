using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMvcProject.Infrastructure.Persisance
{
    public class BookstoreDbContext : DbContext
    {
        DbSet<ExampleMvcProject.Domain.Entities.Bookstore> Bookstores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookstoreDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExampleMvcProject.Domain.Entities.Bookstore>()
                .OwnsOne(c => c.contactDetails);
        }
    }
}
