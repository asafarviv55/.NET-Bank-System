using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.CreditExpenses
{
    public class EditModel : PageModel
    {
        private readonly Bank.Data.BankContext _context;

        public EditModel(Bank.Data.BankContext context)
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

            var creditexpense =  await _context.CreditExpenses.FirstOrDefaultAsync(m => m.id == id);
            if (creditexpense == null)
            {
                return NotFound();
            }
            CreditExpense = creditexpense;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CreditExpense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditExpenseExists(CreditExpense.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CreditExpenseExists(int id)
        {
          return (_context.CreditExpenses?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
