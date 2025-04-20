using backend_sc.DTOs.AlunoDTO;
using backend_sc.DTOs.PessoaDTO;
using backend_sc.Models;
using backend_sc.Services.AlunoService;
using backend_sc.Services.PessoaService;
using Microsoft.AspNetCore.Mvc;

namespace backend_sc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoInterface _alunoInterface;
        public AlunoController(IAlunoInterface alunoInterface)
        {
            _alunoInterface = alunoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AlunoResponseDTO>>>> GetAlunos()
        {
            return Ok(await _alunoInterface.GetAlunos());
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<ServiceResponse<AlunoResponseDTO>>> GetAlunoByCpf(string cpf)
        {
            return Ok(await _alunoInterface.GetAlunoByCpf(cpf));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AlunoResponseDTO>>> GetAlunosById(int id)
        {
            return Ok(await _alunoInterface.GetAlunoById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AlunoResponseDTO>>> CreatePessoa(AlunoCreateDTO newAluno)
        {
            return Ok(await _alunoInterface.CreateAluno(newAluno));
        }

        [HttpPut("inativar/{id}")]
        public async Task<ActionResult<ServiceResponse<AlunoResponseDTO>>> InativarAluno(int id)
        {
            return Ok(await _alunoInterface.InativarAluno(id));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ServiceResponse<AlunoResponseDTO>>> UpdateAluno(int id, [FromBody] AlunoUpdateDTO editAluno)
        {
            return Ok(await _alunoInterface.UpdateAluno(id, editAluno));
        }
    }
}
