using backend_sc.DTOs.AlunoDTO;
using backend_sc.Models;
using backend_sc.Services.AlunoService;
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
    }
}
