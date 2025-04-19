using backend_sc.DTOs.AlunoDTO;
using backend_sc.DTOs.PessoaDTO;
using backend_sc.Models;

namespace backend_sc.Services.AlunoService
{
    public interface IAlunoInterface
    {
        Task<ServiceResponse<List<AlunoResponseDTO>>> GetAlunos();
        Task<ServiceResponse<AlunoResponseDTO>> CreateAluno(AlunoCreateDTO newAluno);
        Task<ServiceResponse<AlunoResponseDTO>> GetAlunoById(int id);
        Task<ServiceResponse<AlunoResponseDTO>> UpdateAluno(AlunoModel editAluno);
        Task<ServiceResponse<bool>> DeleteAluno(int id);
        Task<ServiceResponse<AlunoResponseDTO>> InativaAluno(int id);
    }
}
