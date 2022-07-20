using Microsoft.AspNetCore.Identity;

namespace Bank.Models
{
    public class ApplicationUser : IdentityUser
    {

        public List<Loan> Loans { get; set; }

    }
}
