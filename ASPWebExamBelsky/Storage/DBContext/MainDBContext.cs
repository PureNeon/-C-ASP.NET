using Microsoft.EntityFrameworkCore;

namespace ASPWebExamBelsky.Storage.DBContext
{
    public class MainDBContext : DbContext
    {
        public DbSet<Storage.Entity.Order> Order { get; set; }
        public DbSet<Storage.Entity.Product> Product { get; set; }
        public DbSet<Storage.Entity.ProductInOrder> ProductInOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string useConnection = configuration.GetSection("UseConnection").Value ?? "DefaultConnection";
            string? connectionString = configuration.GetConnectionString(useConnection);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
