using AutoMapper;
using backend_sc.DataContext;
using backend_sc.DTOs.PessoaDTO;
using backend_sc.Enums;
using backend_sc.Models;
using backend_sc.Security;
using Microsoft.EntityFrameworkCore;

namespace backend_sc.Services.PessoaService
{
    public class PessoaService : IPessoaInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        
        public PessoaService(ApplicationDbContext context, IMapper mapper, IPasswordHasher passwordHasher) 
        { 
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<ServiceResponse<PessoaResponseDTO>> CreatePessoa(PessoaCreateDTO newPessoa)
        {
            ServiceResponse<PessoaResponseDTO> serviceResponse = new ServiceResponse<PessoaResponseDTO>();
            try
            {
                if(newPessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                var pessoaMapeada = _mapper.Map<PessoaModel>(newPessoa);
     
                pessoaMapeada.SenhaHash = _passwordHasher.Hash(newPessoa.Senha);

                _context.Add(pessoaMapeada);
                await _context.SaveChangesAsync();

                var pessoaComPermissao = await _context.Pessoas
                    .Include(p => p.Permissao)
                    .FirstOrDefaultAsync(p => p.Id == pessoaMapeada.Id);

                var pessoaResposta = _mapper.Map<PessoaResponseDTO>(pessoaComPermissao);
                serviceResponse.Dados = pessoaResposta;
                serviceResponse.Mensagem = "Pessoa criada com sucesso!";
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<PessoaModel>> DeletePessoa(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<PessoaModel>> GetPessoaById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<PessoaResponseDTO>>> GetPessoas()
        {
            ServiceResponse<List<PessoaResponseDTO>> serviceResponse = new ServiceResponse<List<PessoaResponseDTO>>();

            try
            {
                var pessoasModel = await _context.Pessoas.Include(p => p.Permissao).ToListAsync(); 

                var pessoasResposta = _mapper.Map<List<PessoaResponseDTO>>(pessoasModel);

                serviceResponse.Dados = pessoasResposta;

                if (serviceResponse.Dados == null || serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }

                serviceResponse.Mensagem = "Dados obtidos com sucesso!";
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
