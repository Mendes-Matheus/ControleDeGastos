using ControleDeGastos.Models;

namespace ControleDeGastos.DTO.Pessoa
{
    public record PessoaComTransacoesDTO(
        long Id,
        string Nome,
        int Idade,
        ICollection<Transacao> Transacoes
    );
}
