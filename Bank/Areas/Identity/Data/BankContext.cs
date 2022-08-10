using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data;

public class BankContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
    }

    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;




    public DbSet<Loan> Loans { get; set; }

    public DbSet<CreditExpense> CreditExpenses { get; set; }

    public DbSet<PassBackOperation> PassBackOperations { get; set; }


    private ApplicationUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<ApplicationUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the external login page in /Areas/Identity/Pages/Account/ExternalLogin.cshtml");
        }
    }


    protected async Task OnModelCreatingAsync(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Loan>().ToTable("Loan");
        modelBuilder.Entity<CreditExpense>().ToTable("CreditExpense");
        //  modelBuilder.Entity<PassBackOperation>().HasQueryFilter(p => p.owner.Id.Equals(2));
        //  modelBuilder.Entity<PassBackOperation>().HasQueryFilter(p => p.owner.Id.Equals(2));
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
