using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.DTO.Transferencia
{
    public record TransferenciaRequestDTO(

        [Required(ErrorMessage = "Informe o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior do que 0")]
        Double valor
    );
}
