using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FormControl.Data;
using FormControl.Models;

namespace FormControl.Pages.Produtos
{
    public class CreateModel : PageModel
    {
        private readonly FormControl.Data.ApplicationDbContext _context;

        public CreateModel(FormControl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Produto Produto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile Imagem)
        {
          if (!ModelState.IsValid || _context.Produtos == null || Produto == null)
            {
                return Page();
            }

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
            using(var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await Imagem.CopyToAsync(stream);
            }

            //salvando imagem no banco

            Produto.Imagem = $"/images/produtos/{nomeArquivo}";

            _context.Produtos.Add(Produto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
