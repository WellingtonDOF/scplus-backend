namespace backend_sc.Services.AulaService
{
    public interface IAulaInterface
    {
        Task<ServiceResponse<List<AulaResponseDTO>>> GetAulas();
        Task<ServiceResponse<AulaResponseDTO>> CreateAula(AlunoCreateDTO newAula);
        Task<ServiceResponse<AulaResponseDTO>> GetAulaById(int id);
        Task<ServiceResponse<AulaResponseDTO>> UpdateAula(int id, AulaUpdateDTO editAula);
        Task<ServiceResponse<bool>> DeleteAula(int id);
    }
}
