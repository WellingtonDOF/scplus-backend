using backend_sc.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_sc.DTOs.VeiculoDTO
{
    public class VeiculoCreateDTO
    {
        [Required]
        [MaxLength(150)]
        public string Placa { get; set; }

        [Required]
        [MaxLength(150)]
        public string Modelo { get; set; }

        [Required]
        [MaxLength(150)]
        public string Marca { get; set; }

        [Required]
        public DateTime AnoFabricacao { get; set; }

        [Required]
        public int Categoria { get; set; }

        [Required]
        public DateTime DataAquisicao { get; set; }
    }
}
