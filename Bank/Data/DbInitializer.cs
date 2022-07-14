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
                new User{ birth_date = DateTime.Now ,created_at = DateTime.Now, created_by = "asaf" , email = "asf@gmail.com" ,  phone_number="0546542487" , updated_at = DateTime.Now},
                new User{ birth_date = DateTime.Now ,created_at = DateTime.Now, created_by = "fddsfs" , email = "32@gmail.com" , phone_number="0546525487" , updated_at = DateTime.Now},
                new User{ birth_date = DateTime.Now ,created_at = DateTime.Now, created_by = "fdsfs" , email = "fds@gmail.com" , phone_number="0433453535" , updated_at = DateTime.Now},
                new User{ birth_date = DateTime.Now ,created_at = DateTime.Now, created_by = "fddsfs" , email = "322@gmail.com" , phone_number="0234545634" , updated_at = DateTime.Now},
                new User{ birth_date = DateTime.Now ,created_at = DateTime.Now, created_by = "fdsdsfs" , email = "fddss@gmail.com" , phone_number="0433453545" , updated_at = DateTime.Now}

            };

            context.Users.AddRange(users);
            context.SaveChanges();


            /*********************************/
            // Look for any UsersAuths.

            if (context.UsersAuths.Any())
            {
                return;   // DB has been seeded
            }

            var usersAuths = new UsersAuth[]
            {
                new UsersAuth{owner = new User{ birth_date = DateTime.Now ,created_at = DateTime.Now, created_by = "asaf" , email = "asf@gmail.com" , phone_number="0546522487" , updated_at = DateTime.Now} }

            };

            context.UsersAuths.AddRange(usersAuths);
            context.SaveChanges();
        }
    }
}
