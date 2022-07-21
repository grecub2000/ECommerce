namespace ECommerce.Helpers;

using Microsoft.EntityFrameworkCore;
using ECommerce.Entities;
using Microsoft.EntityFrameworkCore.Design;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }

}


public class ECommerceContextDesignFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseSqlServer("Server=,;Initial Catalog=ECommerceDb;Integrated Security=true");

        return new DataContext(optionsBuilder.Options);
    }
}