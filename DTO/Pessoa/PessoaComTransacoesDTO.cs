using ControleDeGastos.Model;

namespace ControleDeGastos.DTO.Pessoa
{
    public record PessoaComTransacoesDTO(
        long Id,
        string Nome,
        int Idade,
        ICollection<TransacaoModel> Transacoes
    );
}
