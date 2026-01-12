using CompartamosAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CompartamosAppBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
            new Account { Id = 1, AccountNumber = "ACC-0001", Balance = 1000m },
            new Account { Id = 2, AccountNumber = "ACC-0002", Balance = 250m }
        );

        base.OnModelCreating(modelBuilder);
    }
}
