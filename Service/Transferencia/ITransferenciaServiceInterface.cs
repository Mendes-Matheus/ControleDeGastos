using ControleDeGastos.DTO.Transferencia;
using ControleDeGastos.Model;

namespace ControleDeGastos.Service.Transferencia
{
    public interface ITransferenciaServiceInterface
    {
        Task<ResponseModel<List<TransferenciaResponseDTO>>> Transferir(long remetenteId, long destinatarioId, double valor);

    }
}
