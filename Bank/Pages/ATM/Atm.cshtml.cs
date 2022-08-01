using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bank.Pages.ATM
{
    public class AtmModel : PageModel
    {
        private readonly Bank.Data.BankContext _context;

        private readonly ILogger<IndexModel> _logger;

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




        public void OnPost()
        {
            decimal n1; decimal aAmount = 0;

            if (Decimal.TryParse(atmAmount, out n1))
                aAmount = n1;

            using (_context)
            {
                var passBackOperation = new PassBackOperation()
                {
                    account_balance = 343,
                    action = bankAction,
                    created_at = DateTime.UtcNow,
                    due_balance = 0,
                    right_balance = aAmount,
                    owner = 1,
                    reference = ""
                };
                _context.PassBackOperations.Add(passBackOperation);
                _context.SaveChanges();
                int id = passBackOperation.id;
            }
        }


    }
}
