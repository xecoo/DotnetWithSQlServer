namespace Project.Infra.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasMaxLength(80);
            
            modelBuilder.Entity<Product>()
                .Property(x => x.Description)
                .HasMaxLength(180);

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Shampoo", Description = "Isso é um shampoo" },
                    new Product { Id = 2, Name = "Condicionador", Description = "Isso é um condicionador" },
                    new Product { Id = 3, Name = "sabonete", Description = "Isso é um sabonete" }
                );
        }
    }
}