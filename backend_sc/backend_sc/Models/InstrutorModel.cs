using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_sc.Models
{
    public class InstrutorModel : PessoaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(22)]
        public string CategoriaCnh { get; set; }
        [Required]
        public DateTime DataAdmissao { get; set; }

        //Chave estrangeira (PessoaId) já está na classe base (Id), não precisa declarar aqui
        // O relacionamento (herança) com Pessoa é implícito. 
        //Propriedade de navegação existe na classe base, classes filhas herdam essa propriedade.

        //O EF Core gerencia Propriedade de navegação e Id pela herança
    }
}
