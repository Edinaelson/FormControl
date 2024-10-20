﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FormControl.Models
{
    public class Produto : Entity
    {

        public Guid FornecedorId { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Descricao { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Imagem { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Valor { get; set; }

        public DateTime? DataCadastro { get; set; }
        public bool Ativo { get; set; }


        /* EF Relation */
        public Fornecedor? Fornecedores { get; set; }



    }
}
