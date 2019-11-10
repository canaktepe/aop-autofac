
using System.Data.Entity;
using AOP.Database.Entities;

namespace AOP.Database
{
    public class Context : DbContext
    {
        static Context()
        {
           System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }

        public Context() : base(nameof(Context))
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}