using LibraryManager.Infra.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infra.Config;

public sealed class DataContext : DbContext
{
    public DbSet<BookEntity> Book { get; set; }
    public DbSet<AuthorEntity> Author { get; set; }
    public DbSet<CustomerEntity> Customer { get; set; }
    public DbSet<RentEntity> Rent { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEntity>()
            .HasKey(b => b.Id);
        modelBuilder.Entity<AuthorEntity>()
            .Property(a => a.Birth)
            .HasColumnType("datetime");
        
        modelBuilder.Entity<AuthorEntity>()
            .HasKey(a => a.Id);
            
        modelBuilder.Entity<CustomerEntity>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<RentEntity>()
            .HasKey(r => r.RentalId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost, 3306;Database=DB_MANAGER_BOOK;User=root;Password=root;", 
            new MySqlServerVersion(new Version(9, 0, 21)), 
            options => options.MigrationsAssembly("LibraryManager.Infra"));
            
        base.OnConfiguring(optionsBuilder);
    }
}