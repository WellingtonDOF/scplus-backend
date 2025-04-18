using backend_sc.DTOs.PessoaDTO;
using backend_sc.Models;

namespace backend_sc.Services.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<PessoaResponseDTO>>> GetPessoas();
        Task<ServiceResponse<PessoaResponseDTO>> CreatePessoa(PessoaCreateDTO newPessoa);
        Task<ServiceResponse<PessoaModel>> GetPessoaById(int id);
        Task<ServiceResponse<PessoaModel>> UpdatePessoa(PessoaModel editPessoa);
        Task<ServiceResponse<PessoaModel>> DeletePessoa(int id);
        Task<ServiceResponse<PessoaModel>> InativaPessoa(int id);
    }
}
