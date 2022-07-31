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

        }


    }
}
