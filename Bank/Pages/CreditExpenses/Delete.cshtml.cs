using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.CreditExpenses
{
    public class DeleteModel : PageModel
    {
        private readonly Bank.Data.BankContext _context;

        public DeleteModel(Bank.Data.BankContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CreditExpense CreditExpense { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CreditExpenses == null)
            {
                return NotFound();
            }

            var creditexpense = await _context.CreditExpenses.FirstOrDefaultAsync(m => m.id == id);

            if (creditexpense == null)
            {
                return NotFound();
            }
            else 
            {
                CreditExpense = creditexpense;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CreditExpenses == null)
            {
                return NotFound();
            }
            var creditexpense = await _context.CreditExpenses.FindAsync(id);

            if (creditexpense != null)
            {
                CreditExpense = creditexpense;
                _context.CreditExpenses.Remove(CreditExpense);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
