using Bank.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data;

public class BankContext : IdentityDbContext<IdentityUser>
{
    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }

    public DbSet<UsersAuth> UsersAuths { get; set; }

    public DbSet<Loan> Loans { get; set; }

    public DbSet<CreditExpense> CreditExpenses { get; set; }

    public DbSet<PassBackOperation> PassBackOperations { get; set; }





    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<UsersAuth>().ToTable("UsersAuth");
        modelBuilder.Entity<Loan>().ToTable("Loan");
        modelBuilder.Entity<CreditExpense>().ToTable("CreditExpense");
        modelBuilder.Entity<PassBackOperation>().ToTable("PassBackOperation");
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
