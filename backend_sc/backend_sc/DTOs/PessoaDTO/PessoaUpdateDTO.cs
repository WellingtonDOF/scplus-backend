using System.ComponentModel.DataAnnotations;

namespace backend_sc.DTOs.PessoaDTO
{
    public class PessoaUpdateDTO
    {
        [MaxLength(150)]
        public string NomeCompleto { get; set; }

        [MaxLength(150)]
        public string Endereco { get; set; }

        [Phone]
        [MaxLength(22)]
        public string Telefone { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
