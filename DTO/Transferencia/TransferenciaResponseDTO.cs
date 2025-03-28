namespace ControleDeGastos.DTO.Transferencia
{
    public record TransferenciaResponseDTO(
        string descricao,
        string remetente,
        string destinatario,
        string dataHora,
        double valor
    );
    
}
