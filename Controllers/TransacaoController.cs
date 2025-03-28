using ControleDeGastos.DTO.Transacao;
using ControleDeGastos.Model;
using ControleDeGastos.Service.Transacao;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.Controllers
{

    // Define a rota da API para o controlador de Transacao
    [Route("api/[controller]")]
    [ApiController] // Indica que esta classe é um controlador da API
    public class TransacaoController : Controller
    {
        // Declaração de um campo para a interface de serviço de Transacao
        private readonly ITransacaoServiceInterface _transacaoServiceInterface;

        // Construtor que injeta a dependência do serviço de Transacao
        public TransacaoController(ITransacaoServiceInterface transacaoServiceInterface)
        {
            _transacaoServiceInterface = transacaoServiceInterface;
        }

        // Salva uma transação
        [HttpPost("save/{pessoaId}")]
        public async Task<ActionResult<ResponseModel<List<TransacaoModel>>>> Save(long pessoaId, [FromBody] TransacaoRequestDTO transacaoRequestDTO)
        {
            // Chama o método de serviço para salvar a transacao e aguarda a resposta assíncrona
            var transacao = await _transacaoServiceInterface.Save(pessoaId, transacaoRequestDTO);

            // Retorna a resposta da API com o status HTTP 200 (Ok) e os dados de resposta
            return Ok(transacao);
        }

        // Retorna todas as transações registradas no sistema.
        [HttpGet("getAll")]
        public async Task<ActionResult<ResponseModel<List<TransacaoModel>>>> GetAll()
        {
            // Chama o serviço para obter todas as transações
            var transacoes = await _transacaoServiceInterface.GetAll();

            // Retorna a lista de transações com um status HTTP 200 (Ok)
            return Ok(transacoes);
        }

    }


}
