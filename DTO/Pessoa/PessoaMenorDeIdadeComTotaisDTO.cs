namespace ControleDeGastos.DTO.Pessoa
{
    public record PessoaMenorDeIdadeComTotaisDTO(
        long Id, 
        string Nome, 
        int Idade, 
        double Mesada, 
        double Despesas, 
        double Saldo
    );

}
