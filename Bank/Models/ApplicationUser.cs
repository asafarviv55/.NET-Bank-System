using Microsoft.AspNetCore.Identity;

namespace Bank.Models
{
    public class ApplicationUser : IdentityUser<int>
    {



        public List<Loan> Loans { get; set; }

        public List<PassBackOperation> passBackOperations { get; set; }

        public static explicit operator ApplicationUser(Task<ApplicationUser> v)
        {
            throw new NotImplementedException();
        }
    }
}
