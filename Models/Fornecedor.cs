using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace FormControl.Models
{
    public class Fornecedor : Entity
    {
        [Display(Name ="Fornecedor")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        public TipoFornecedor TipoFornecedor { get; set; }


        /*EF Relations */
        public IEnumerable<Produto>? Produtos { get; set; }

        public string FormatarDocumento()
        {

            if (Documento.Length >= 11)
            {
                return Convert.ToUInt64(Documento.Replace(".","").Replace("/","").Replace("-","")).ToString(@"000\.000\.000\-00");
            }
            else if (Documento.Length == 14)
            {
                // Formatar como CNPJ
                return Convert.ToUInt64(Documento).ToString(@"00\.000\.000\/0000\-00");
            }

            return Documento;
        }

        /* public string RemoverCaracteresEspeciais(string fornecedor)
        {
            return fornecedor;
        } */

    }

    public class Foo
    {
        public string Paises { get; set; }
        public string Capital { get; set; }

    }

}
