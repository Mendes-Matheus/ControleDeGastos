namespace ControleDeGastos.DTO.Pessoa
{
    public record PessoaMenorComTotaisDTO(
        long Id,
        string Nome,
        int Idade,
        double Mesada,
        double Despesas,
        double Saldo
    );
}
