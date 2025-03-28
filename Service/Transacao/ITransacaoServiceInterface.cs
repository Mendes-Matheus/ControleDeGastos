using ControleDeGastos.DTO.Transacao;
using ControleDeGastos.Model;

namespace ControleDeGastos.Service.Transacao
{
    public interface ITransacaoServiceInterface
    {
        Task<ResponseModel<List<TransacaoModel>>> Save(long pessoaId, TransacaoRequestDTO transacaoRequestDTO);
        Task<ResponseModel<List<TransacaoModel>>> GetAll();

    }
}
