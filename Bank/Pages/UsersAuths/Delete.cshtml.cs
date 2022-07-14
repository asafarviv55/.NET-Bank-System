using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.UsersAuths
{
    public class DeleteModel : PageModel
    {
        private readonly Bank.Data.BankContext _context;

        public DeleteModel(Bank.Data.BankContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UsersAuth UsersAuth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UsersAuths == null)
            {
                return NotFound();
            }

            var usersauth = await _context.UsersAuths.FirstOrDefaultAsync(m => m.id == id);

            if (usersauth == null)
            {
                return NotFound();
            }
            else 
            {
                UsersAuth = usersauth;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UsersAuths == null)
            {
                return NotFound();
            }
            var usersauth = await _context.UsersAuths.FindAsync(id);

            if (usersauth != null)
            {
                UsersAuth = usersauth;
                _context.UsersAuths.Remove(UsersAuth);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
