using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_sc.Models
{
    public class InstrutorModel : PessoaModel
    {
        [MaxLength(22)]
        public string CategoriaCnh { get; set; }
        [Required]
        public DateTime DataAdmissao { get; set; }

        //Propriedade de navegação para a entidade permissão (traz eficiência) 
        public PessoaModel Pessoa{ get; set; }
    }
}
