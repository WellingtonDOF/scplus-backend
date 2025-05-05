using AutoMapper;
using backend_sc.DataContext;
using backend_sc.DTOs.AlunoDTO;
using backend_sc.DTOs.MatriculaDTO;
using backend_sc.Enums;
using backend_sc.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_sc.Services.MatriculaService
{
    public class MatriculaService : IMatriculaInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MatriculaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<MatriculaResponseDTO>> CreateMatricula(MatriculaCreateDTO newMatricula)
        {
            var serviceResponse = new ServiceResponse<MatriculaResponseDTO>();

            try
            {
                if (newMatricula == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Dados inválidos!";
                    return serviceResponse;
                }

                var matriculaExistente = await _context.Matricula.FirstOrDefaultAsync(p => p.AlunoId == newMatricula.AlunoId);

                if (matriculaExistente != null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = $"O usuário já está cadastrado em uma matrícula!";
                    return serviceResponse;
                }

                var matriculaModel = _mapper.Map<MatriculaModel>(newMatricula);
                matriculaModel.DataInicio = DateTime.Now;
                matriculaModel.StatusMatricula = true;

                _context.Matricula.Add(matriculaModel);
                await _context.SaveChangesAsync();

                var matriculaResponse = _mapper.Map<MatriculaResponseDTO>(matriculaModel);
                serviceResponse.Dados = matriculaResponse;
                serviceResponse.Mensagem = "Matrícula criada com sucesso!";
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<bool>> DeleteMatricula(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<MatriculaResponseDTO>> GetMatriculaById(int id)
        {
            ServiceResponse<MatriculaResponseDTO> serviceResponse = new ServiceResponse<MatriculaResponseDTO>();

            try
            {
                var matriculaMapeada = await _context.Matricula.Include(m => m.Aluno).FirstOrDefaultAsync(p => p.Id == id);

                if (matriculaMapeada == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Erro ao encontrar matrícula";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                var matriculaResposta = _mapper.Map<MatriculaResponseDTO>(matriculaMapeada);
                serviceResponse.Dados = matriculaResposta;
                serviceResponse.Mensagem = "Dados obtidos com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MatriculaResponseDTO>>> GetMatriculas()
        {
            ServiceResponse<List<MatriculaResponseDTO>> serviceResponse = new ServiceResponse<List<MatriculaResponseDTO>>();

            try
            {
                var matriculaModel = await _context.Matricula.Include(m => m.Aluno).ToListAsync();

                var matriculaResposta = _mapper.Map<List<MatriculaResponseDTO>>(matriculaModel);

                serviceResponse.Dados = matriculaResposta;

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

        public async Task<ServiceResponse<MatriculaResponseDTO>> MudarStatusMatricula(int id)
        {
            ServiceResponse<MatriculaResponseDTO> serviceResponse = new ServiceResponse<MatriculaResponseDTO>();

            try
            {
                var matriculaMapeada = await _context.Matricula.FirstOrDefaultAsync(a => a.Id == id);

                if (matriculaMapeada == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Erro ao encontrar matrícula";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                if (matriculaMapeada.StatusMatricula == true)
                {
                    matriculaMapeada.StatusMatricula = false;
                    matriculaMapeada.DataFim=DateTime.Now;
                }
                else 
                { 
                    matriculaMapeada.StatusMatricula = true;
                    matriculaMapeada.DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0);
                }

                await _context.SaveChangesAsync();

                serviceResponse.Dados = _mapper.Map<MatriculaResponseDTO>(matriculaMapeada); ;
                serviceResponse.Mensagem = $"Mudança para '{(matriculaMapeada.StatusMatricula== true ? "Ativo" : "Inativo")}' concluída!";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> VerificarCpfExistente(string cpf)
        {
            var response = new ServiceResponse<int>();

            try
            {
                // 1. Validação básica do CPF
                if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
                {
                    response.Sucesso = false;
                    response.Mensagem = "CPF inválido";
                    response.Dados = -1;
                    return response;
                }

                // 2. Verifica se o aluno existe e se já tem matrícula
                var resultado = await _context.Pessoas
                    .Where(a => a.Cpf == cpf)
                    .Select(a => new {
                        a.Id,
                        TemMatricula = _context.Matricula.Any(m => m.AlunoId == a.Id)
                    })
                    .FirstOrDefaultAsync();

                if (resultado == null)
                {
                    response.Dados = -1;
                    response.Sucesso = false;
                    response.Mensagem = "CPF não cadastrado no sistema.";
                }
                else if (resultado.TemMatricula)
                {
                    response.Dados = -1;
                    response.Sucesso = false;
                    response.Mensagem = "Usuário já possui matrícula ativa.";
                }
                else
                {
                    response.Dados = resultado.Id; 
                    response.Mensagem = "CPF válido e disponível para matrícula.";
                }
            }
            catch (Exception ex)
            {
                response.Dados = -1;
                response.Mensagem = $"Erro: {ex.Message}";
                response.Sucesso = false;
            }

            return response;
        }

        public async Task<ServiceResponse<MatriculaResponseDTO>> UpdateMatricula(int id, MatriculaUpdateDTO editMatricula)
        {
            ServiceResponse<MatriculaResponseDTO> serviceResponse = new ServiceResponse<MatriculaResponseDTO>();

            try
            {
                var matriculaMapeada = await _context.Matricula.FirstOrDefaultAsync(a => a.Id == id);

                if (matriculaMapeada == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Matrícula não encontrada.";
                    return serviceResponse;
                }

                _mapper.Map(editMatricula, matriculaMapeada);

                _context.Matricula.Update(matriculaMapeada);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _mapper.Map<MatriculaResponseDTO>(matriculaMapeada);
                serviceResponse.Mensagem = "Matrícula atualizada com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
