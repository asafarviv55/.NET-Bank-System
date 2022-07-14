using Bank.Models;

namespace Bank.Data
{
    public class DbInitializer
    {
        public static void Initialize(BankContext context)
        {
            // Look for any Users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{}

            };

            context.Users.AddRange(users);
            context.SaveChanges();


            /*********************************/
            // Look for any students.
            if (context.UsersAuths.Any())
            {
                return;   // DB has been seeded
            }

            var usersAuths = new UsersAuth[]
            {
                new UsersAuth{owner}

            };

            context.UsersAuths.AddRange(usersAuths);
            context.SaveChanges();
        }
    }
}
