using Microsoft.EntityFrameworkCore;

namespace RepositorySample
{
    public class DataContext : DbContext
    {
        public DbSet<SimpleClassObject> RepoOneObjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                // .UseLazyLoadingProxies()
                .UseSqlite("Data Source=orders.db");
        }
    }
}