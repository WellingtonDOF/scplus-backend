namespace backend_sc.DTOs.AulaDTO
{
    public class AulaCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string TipoAula { get; set; }

        [required]
        [MaxLength(250)]
        public string Descricao { get; set; }
    }
}
