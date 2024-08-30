using Microsoft.EntityFrameworkCore;

namespace ExampleMvcProject.MVC.Entities
{
    public class BookstoreDbContext : DbContext
    {
        //private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookstoreDb;Integrated Security=True;";
        public DbSet<Book> books { get; set; }
        public DbSet<Audiobook> audiobooks { get; set; }
        public DbSet<Music> musics { get; set; }
        public DbSet<Film> films { get; set; }
        public DbSet<Basket> baskets { get; set; }

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
