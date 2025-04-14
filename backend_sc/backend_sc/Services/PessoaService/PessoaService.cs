using backend_sc.DataContext;
using backend_sc.Models;

namespace backend_sc.Services.PessoaService
{
    public class PessoaService : IPessoaInterface
    {
        private readonly ApplicationDbContext _context;
        public PessoaService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public Task<ServiceResponse<PessoaModel>> CreatePessoa(PessoaModel newPessoa)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<PessoaModel>> DeletePessoa(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<PessoaModel>> GetPessoaById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<PessoaModel>>> GetPessoas()
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                serviceResponse.Dados = _context.Pessoas.ToList();
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<PessoaModel>> InativaPessoa(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<PessoaModel>> UpdatePessoa(PessoaModel editPessoa)
        {
            throw new NotImplementedException();
        }
    }
}
