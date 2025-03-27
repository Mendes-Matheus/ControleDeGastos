using ControleDeGastos.DTO.Pessoa;
using ControleDeGastos.Model;
using ControleDeGastos.Service.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {


        private readonly IPessoaServiceInterface _pessoaServiceInterface;

        public PessoaController(IPessoaServiceInterface pessoaServiceInterface)
        {
            _pessoaServiceInterface = pessoaServiceInterface;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}
