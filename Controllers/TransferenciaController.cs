using ControleDeGastos.DTO.Transferencia;
using ControleDeGastos.Model;
using ControleDeGastos.Service.Transacao;
using ControleDeGastos.Service.Transferencia;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.Controllers
{
    // Define a rota da API para o controlador de Transferencia
    [Route("api/[controller]")]
    [ApiController] // Indica que esta classe é um controlador da API
    public class TransferenciaController : Controller
    {
        // Declaração de um campo para a interface de serviço de Transferencia
        private readonly ITransferenciaServiceInterface _transferenciaServiceInterface;
        // Declaração de um campo para a interface de serviço de Transacao
        private readonly ITransacaoServiceInterface _transacaoServiceInterface;

        // Construtor que injeta a dependência do serviço de Transferencia
        public TransferenciaController(ITransferenciaServiceInterface transferenciaServiceInterface, ITransacaoServiceInterface transacaoServiceInterface)
        {
            _transferenciaServiceInterface = transferenciaServiceInterface;
            _transacaoServiceInterface = transacaoServiceInterface;
        }

        [HttpPost("transferir/{remetenteId}/{destinatarioId}")]
        public async Task<ActionResult<ResponseModel<List<TransferenciaResponseDTO>>>> Transferir(
                long remetenteId,
                long destinatarioId,
                [FromBody] TransferenciaRequestDTO transferenciaRequestDTO)
        {
            // Chama o serviço para realizar a transferência
            var resposta = await _transferenciaServiceInterface.Transferir(remetenteId, destinatarioId, transferenciaRequestDTO.valor);

            // Retorna a resposta do serviço
            return Ok(resposta);
        }

    }
}
