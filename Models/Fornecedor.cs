using System.ComponentModel.DataAnnotations;

namespace FormControl.Models
{
    public class Fornecedor : Entity
    {
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        public TipoFornecedor TipoCliente { get; set; }


        /*EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }

    }
}
