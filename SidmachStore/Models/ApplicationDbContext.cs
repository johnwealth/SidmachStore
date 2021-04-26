using Microsoft.EntityFrameworkCore;

namespace SidmachStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

/*
public class SidmachContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CustomerContext, ProductContext>();
        optionsBuilder.UseSqlite("Data Source=SidmachStore.db");

        return new ApplicaionDbContext(optionsBuilder.Options);
    }
}*/