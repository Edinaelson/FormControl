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
    public class IndexModel : PageModel
    {
        private readonly FormControl.Data.ApplicationDbContext _context;

        public IndexModel(FormControl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Fornecedor> Fornecedor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Fornecedores != null)
            {
                Fornecedor = await _context.Fornecedores.ToListAsync();
            }
        }
    }
}
