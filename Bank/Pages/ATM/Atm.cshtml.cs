using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bank.Pages.ATM
{
    public class AtmModel : PageModel
    {
        private readonly Bank.Data.BankContext _context;

        private readonly ILogger<IndexModel> _logger;
        private const string DEPOSIT = "DEPOSIT";
        private const string WITHDRAW = "WITHDRAW";
        public AtmModel(ILogger<IndexModel> logger, BankContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public string bankAction { get; set; }

        [BindProperty]
        public string atmAmount { get; set; }


        private String getRandomAlphaNumericString()
        {
            var chars = "1234567890";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public void OnPost()
        {
            decimal n1; decimal aAmount = 0;
            if (Decimal.TryParse(atmAmount, out n1))
                aAmount = n1;
            var passBackOperation = new PassBackOperation()
            {
                account_balance = aAmount,
                action = bankAction.Equals("Deposit") ? DEPOSIT : WITHDRAW,
                created_at = DateTime.UtcNow,
                due_balance = bankAction.Equals("Deposit") ? 0 : aAmount,
                right_balance = bankAction.Equals("Withdraw") ? aAmount : 0,
                owner = new ApplicationUser(),
                reference = getRandomAlphaNumericString()
            };
            _context.PassBackOperations.Add(passBackOperation);
            _context.SaveChanges();
            int id = passBackOperation.id;
        }


    }
}
