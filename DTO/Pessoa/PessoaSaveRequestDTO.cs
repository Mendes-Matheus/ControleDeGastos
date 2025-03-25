using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.DTO.Pessoa
{
    public record PessoaSaveRequestDTO
    {
        [Required(ErrorMessage = "Informe a idade")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Infome a idade")]
        [Range(0, int.MaxValue, ErrorMessage = "A idade deve ser maior ou igual a zero")]
        public required int Idade { get; set; }
    }
}
