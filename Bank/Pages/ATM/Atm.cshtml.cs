using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bank.Pages.ATM
{
    public class AtmModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public AtmModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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
