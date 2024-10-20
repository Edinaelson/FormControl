using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormControl.Data;
using FormControl.Models;
using static System.Net.Mime.MediaTypeNames;

namespace FormControl.Pages.Produtos
{
    public class EditModel : PageModel
    {
        private readonly FormControl.Data.ApplicationDbContext _context;

        public EditModel(FormControl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produto Produto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto =  await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            Produto = produto;
           ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile Imagem)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            /* Tratamento de imagens*/
            //definir onde o caminho da imagem sera salva
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/produtos");
            var nomeArquivo = Path.GetFileName(Imagem.FileName);
            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            //cria a pasta se ela não existir
            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }

            //salvar arquivo no caminho especificado
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await Imagem.CopyToAsync(stream);
            }

            //salvando imagem no banco

            Produto.Imagem = $"/images/produtos/{nomeArquivo}";
            /* Fim Tratamento de imagens*/


            _context.Attach(Produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Produto.Id))
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

        private bool ProdutoExists(Guid id)
        {
          return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
