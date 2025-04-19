using AutoMapper;
using backend_sc.DataContext;
using backend_sc.DTOs.AlunoDTO;
using backend_sc.DTOs.PessoaDTO;
using backend_sc.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_sc.Services.AlunoService
{
    public class AlunoService : IAlunoInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AlunoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AlunoResponseDTO>> CreateAluno(AlunoCreateDTO newAluno)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteAluno(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AlunoResponseDTO>> GetAlunoById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<AlunoResponseDTO>>> GetAlunos()
        {
            ServiceResponse<List<AlunoResponseDTO>> serviceResponse = new ServiceResponse<List<AlunoResponseDTO>>();

            try
            {
                var alunoModel = await _context.Alunos.Include(p=> p.Permissao).ToListAsync();

                var alunosResposta = _mapper.Map<List<AlunoResponseDTO>>(alunoModel);

                serviceResponse.Dados = alunosResposta;

                if (serviceResponse.Dados == null || serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                    return serviceResponse;
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

        public Task<ServiceResponse<AlunoResponseDTO>> InativaAluno(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AlunoResponseDTO>> UpdateAluno(AlunoModel editAluno)
        {
            throw new NotImplementedException();
        }
    }
}
