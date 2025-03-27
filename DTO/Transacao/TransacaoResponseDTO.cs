using ControleDeGastos.Model;

namespace ControleDeGastos.DTO.Transacao
{
    public record TransacaoResponseDTO(
        string descricao,
        double valor,
        TransacaoTipo tipo
    );
}
