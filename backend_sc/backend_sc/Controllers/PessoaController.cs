using backend_sc.Services.PessoaService;
using Microsoft.AspNetCore.Mvc;

namespace backend_sc.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaInterface _pessoaService;
        public PessoaController(IPessoaInterface pessoaInterface) 
        {
            _pessoaService = pessoaInterface;   
        }

        [HttpGet]
        public ActionResult GetPessoas()
        {
            return Ok("teste");
        }

    }
}
