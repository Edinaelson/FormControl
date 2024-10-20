using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormControl.Data;
using FormControl.Models;

namespace FormControl.Pages.Fornecedores
{
    public class DeleteModel : PageModel
    {
        private readonly FormControl.Data.ApplicationDbContext _context;

        public DeleteModel(FormControl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Fornecedor Fornecedor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(m => m.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            else 
            {
                Fornecedor = fornecedor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }
            var fornecedor = await _context.Fornecedores.FindAsync(id);

            if (fornecedor != null)
            {
                Fornecedor = fornecedor;
                _context.Fornecedores.Remove(Fornecedor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
