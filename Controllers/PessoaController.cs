using ControleDeGastos.DTO.Pessoa;
using ControleDeGastos.Model;
using ControleDeGastos.Service.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.Controllers
{
    // Define a rota da API para o controlador de Pessoa
    [Route("api/[controller]")]
    [ApiController] // Indica que esta classe é um controlador da API
    public class PessoaController : Controller
    {

        // Declaração de um campo para a interface de serviço de Pessoa
        private readonly IPessoaServiceInterface _pessoaServiceInterface;

        // Construtor que injeta a dependência do serviço de Pessoa
        public PessoaController(IPessoaServiceInterface pessoaServiceInterface)
        {
            _pessoaServiceInterface = pessoaServiceInterface;
        }


        // Método GET que retorna uma View, típica de uma aplicação MVC, usada para exibir uma página ou informações visuais
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Método POST para salvar uma nova pessoa
        [HttpPost("save")]
        public async Task<ActionResult<ResponseModel<List<PessoaModel>>>> Save(PessoaSaveRequestDTO pessoaSaveRequestDTO)
        {
            // Chama o método de serviço para salvar a pessoa e aguarda a resposta assíncrona
            var autores = await _pessoaServiceInterface.Save(pessoaSaveRequestDTO);

            // Retorna a resposta da API com o status HTTP 200 (Ok) e os dados de resposta
            return Ok(autores);
        }

    }
}
