namespace ControleDeGastos.DTO.Pessoa
{
    public record PessoaComTotaisDTO(
        long Id, 
        string Nome, 
        int Idade, 
        double Receitas, 
        double Despesas, 
        double Saldo
    );

}
