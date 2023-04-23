using BookStoreWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data
{
    //.....we inherit from IdentityDbContext insted of DbContext, to work with Identity for security

    //..
    //...the standard is IdentityDbContext
    //..the custom on identity is IdentityDbContext<ApplicationUser>
    public class BookStoreWebContext : IdentityDbContext<ApplicationUser>
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
