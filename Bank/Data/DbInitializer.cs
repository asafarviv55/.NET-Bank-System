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
                new UsersAuth{
                    owner = new User{ birth_date = DateTime.Now ,created_at = DateTime.Now, created_by = "asaf" , email = "asf@gmail.com" , phone_number="0546522487" , updated_at = DateTime.Now}
                    ,created_at=DateTime.Now
                    ,password="sadd322"
                    , username="asadf" }

            };

            context.UsersAuths.AddRange(usersAuths);
            context.SaveChanges();



            /*********************************/
            // Look for any Loans.

            if (context.Loans.Any())
            {
                return;   // DB has been seeded
            }

            var loans = new Loan[]
            {
                new Loan{ created_at = DateTime.Now , loan_balance = 1000,  owner = new User{ birth_date = DateTime.Now ,created_at = DateTime.Now, created_by = "asaf" , email = "asf@gmail.com" , phone_number="0546522487" , updated_at = DateTime.Now} }

            };

            context.Loans.AddRange(loans);
            context.SaveChanges();


            /**************************************/
            /*********************************/
            // Look for any PassBackOperations.

            if (context.PassBackOperations.Any())
            {
                return;   // DB has been seeded
            }

            var passBackOperations = new PassBackOperation[]
            {
                new PassBackOperation{ is_charge = true,  account_balance = 1000 , created_at = DateTime.Now
                ,owner= new User { birth_date = DateTime.Now , created_at = DateTime.Now , created_by = "asaf" , email = "asaf.arviv@gmail.com" ,phone_number = "05487534567" ,updated_at = DateTime.Now } }
            };

            context.PassBackOperations.AddRange(passBackOperations);
            context.SaveChanges();

            /**************************************/
            // Look for any CreditExpenses.

            if (context.CreditExpenses.Any())
            {
                return;   // DB has been seeded
            }

            var creditExpenses = new CreditExpense[]
            {
                new CreditExpense{ owner= new User { birth_date = DateTime.Now , created_at = DateTime.Now , created_by = "asaf" , email = "asaf.arviv@gmail.com" ,phone_number = "05487534567" ,updated_at = DateTime.Now } }
            };

            context.CreditExpenses.AddRange(creditExpenses);
            context.SaveChanges();




        }
    }
}
