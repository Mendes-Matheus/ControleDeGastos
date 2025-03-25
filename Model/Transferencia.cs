using ControleDeGastos.Models;

namespace ControleDeGastos.Model
{
    // A classe Transferencia herda de Transacao, portanto ela é um tipo especializado de transação
    public class Transferencia : Transacao
    {
        public string Remetente { get; set; }
        public string Destinatario { get; set; }


        // Construtor que inicializa os valores das propriedades Remetente e Destinatario
        public Transferencia(string remetente, string destinatario)
        {
            Remetente = remetente;
            Destinatario = destinatario;
        }

        // Construtor que chama o construtor da classe base (Transacao) e inicializa as propriedades Remetente e Destinatario
        public Transferencia(long id, string descricao, double valor, DateTime dataHora, TransacaoTipo tipoTransacao, long pessoaId, Pessoa pessoa, string remetente, string destinatario) 
            : base(id, descricao, valor, dataHora, tipoTransacao, pessoaId, pessoa)  // Chama o construtor da classe base Transacao
        {
            Remetente = remetente;
            Destinatario = destinatario;
        }

    }
}
