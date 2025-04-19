using backend_sc.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_sc.Models
{
    public class AlunoModel : PessoaModel
    {
        [Required]
        [MaxLength(22)]
        public string CategoriaCnhDesejada { get; set; }

        [Required]
        public StatusPagamentoEnum StatusPagamento { get; set; }

        [Required]
        public bool StatusCurso { get; set; }
    }
}
