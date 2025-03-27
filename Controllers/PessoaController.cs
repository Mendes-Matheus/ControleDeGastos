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


        // Método POST para salvar uma nova pessoa
        [HttpPost("save")]
        public async Task<ActionResult<ResponseModel<List<PessoaModel>>>> Save(PessoaSaveRequestDTO pessoaSaveRequestDTO)
        {
            // Chama o método de serviço para salvar a pessoa e aguarda a resposta assíncrona
            var autores = await _pessoaServiceInterface.Save(pessoaSaveRequestDTO);

            // Retorna o status HTTP 200 (Ok) e os dados de resposta
            return Ok(autores);
        }

        // Método GET para buscar uma pessoa por ID
        [HttpGet("findById/{idPessoa}")]
        public async Task<ActionResult<ResponseModel<object>>> FindById(int idPessoa)
        {
            // Chama o método de serviço para encontrar a pessoa pelo ID e aguarda a resposta assíncrona
            var responseModel = await _pessoaServiceInterface.FindById(idPessoa);

            // Verifica se a pessoa não foi encontrada
            if (!responseModel.Status)
            {
                return NotFound(responseModel.Mensagem); // Retorna status HTTP 404 (Not Found) com a mensagem de erro
            }

            // Retorna o status HTTP 200 (Ok) e os dados de resposta
            return Ok(responseModel);
        }

        // Método GET para buscar todas as pessoas
        [HttpGet("findAll")]
        public async Task<ActionResult<ResponseModel<List<object>>>> FindAll()
        {
            // Chama o método de serviço para buscar todas as pessoas e aguarda a resposta assíncrona
            var responseModel = await _pessoaServiceInterface.FindAll();

            // Verifica se houve um erro na busca
            if (!responseModel.Status)
            {
                return NotFound(responseModel.Mensagem); // Retorna status HTTP 404 (Not Found) com a mensagem de erro
            }

            // Retorna o status HTTP 200 (Ok) e os dados de resposta
            return Ok(responseModel);
        }

    }
}
