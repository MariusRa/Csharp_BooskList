using FavoriteBook;
using Microsoft.EntityFrameworkCore;


namespace Books.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public string DbPath { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=DESKTOP-QJFRKQB; Initial Catalog=kitm; Integrated security=true;");
        }

    }
}
