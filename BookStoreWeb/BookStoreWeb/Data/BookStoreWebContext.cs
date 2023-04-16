using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data
{
    public class BookStoreWebContext : DbContext
    {
        public BookStoreWebContext(DbContextOptions<BookStoreWebContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        // ...>>>>> connection string  can define here or in startup service <<<<<<.......
        //....start
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;DataBase=BookStore;Integrated Security=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        //...
        //......end

    }
}
