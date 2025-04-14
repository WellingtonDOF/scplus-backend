using backend_sc.Models;

namespace backend_sc.Services.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<PessoaModel>>> GetPessoas();
        Task<ServiceResponse<PessoaModel>> CreatePessoa(PessoaModel newPessoa);
        Task<ServiceResponse<PessoaModel>> GetPessoaById(int id);
        Task<ServiceResponse<PessoaModel>> UpdatePessoa(PessoaModel editPessoa);
        Task<ServiceResponse<PessoaModel>> DeletePessoa(int id);
        Task<ServiceResponse<PessoaModel>> InativaPessoa(int id);
    }
}
