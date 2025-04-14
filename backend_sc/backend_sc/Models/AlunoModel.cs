using backend_sc.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_sc.Models
{
    public class AlunoModel : PessoaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(22)]
        public string CategoriaCnh { get; set; }

        [Required]
        public StatusPagamentoEnum StatusPagamento { get; set; }

        [Required]
        public bool StatusCurso { get; set; }

        //O EF Core gerencia Propriedade de navegação e Id pela herança
    }
}
