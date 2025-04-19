using backend_sc.DTOs.PessoaDTO;
using backend_sc.Models;
using backend_sc.Services.PessoaService;
using Microsoft.AspNetCore.Mvc;

namespace backend_sc.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaInterface _pessoaInterface;
        public PessoaController(IPessoaInterface pessoaInterface) 
        {
            _pessoaInterface = pessoaInterface;   
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PessoaResponseDTO>>>> GetPessoas()
        {
            return Ok( await _pessoaInterface.GetPessoas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PessoaResponseDTO>>> GetPessoaById(int id)
        {
            return Ok(await _pessoaInterface.GetPessoaById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<PessoaResponseDTO>>> CreatePessoa(PessoaCreateDTO newPessoa)
        {
            return Ok(await _pessoaInterface.CreatePessoa(newPessoa));
        }

        [HttpPut("inativar/{id}")]
        public async Task<ActionResult<ServiceResponse<PessoaResponseDTO>>> InativarPessoa(int id)
        {
            return Ok(await _pessoaInterface.InativarPessoa(id));
        }



    }
}
