using System.ComponentModel.DataAnnotations;
using ControleDeGastos.Model;

namespace ControleDeGastos.DTO.Transacao
{
    public record TransacaoRequestDTO(
        [Required(ErrorMessage = "Informe a descrição")]
        string descricao,

        [Required(ErrorMessage = "Informe o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior do que 0")]
        double valor,

        [Required(ErrorMessage = "Informe o tipo")]
        TransacaoTipo tipo
    );
}
