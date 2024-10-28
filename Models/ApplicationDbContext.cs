using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed categories
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Books" },
            new Category { CategoryId = 3, CategoryName = "Clothing" }
        );

        // Generate and seed 100 sample products
        var products = new List<Product>();
        for (int i = 1; i <= 100; i++)
        {
            products.Add(new Product
            {
                ProductId = i,
                ProductName = $"Product {i}",
                CategoryId = (i % 3) + 1 // Distribute products across 3 categories
            });
        }
        
        modelBuilder.Entity<Product>().HasData(products);

        base.OnModelCreating(modelBuilder);
    }
}
