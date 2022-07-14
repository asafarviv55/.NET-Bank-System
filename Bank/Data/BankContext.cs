using Bank.Models;
using Microsoft.EntityFrameworkCore;


namespace Bank.Data
{
    public class BankContext : DbContext
    {

        public BankContext(DbContextOptions<BankContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UsersAuth> UsersAuths { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UsersAuth>().ToTable("UsersAuth");

        }
    }
}
