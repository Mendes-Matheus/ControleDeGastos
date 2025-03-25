using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControleDeGastos.Model;

namespace ControleDeGastos.Models
{

    // Enum que define os tipos possíveis de transações: Despesa, Receita ou Mesada
    public enum TransacaoTipo
    {
        DESPESA,
        RECEITA,
        MESADA
    }

    [Table("Transacao")] // Indica que essa classe mapeia uma tabela chamada "Transacao" no banco de dados
    public class Transacao
    {

        // Define a chave primária da entidade. O valor será gerado automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // A descrição da transação é obrigatória e deve ter no máximo 200 caracteres
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; } = string.Empty;

        // O valor da transação é obrigatório e deve ser maior ou igual a 0.01
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Valor { get; set; }

        // A data e hora da transação é obrigatória
        [Required]
        public DateTime DataHora { get; set; }

        // O tipo da transação é obrigatório e é um valor do tipo TransacaoTipo (DESPESA, RECEITA, MESADA)
        [Required]
        public TransacaoTipo TipoTransacao { get; set; }

        // A chave estrangeira que faz referência à tabela "Pessoa", indicando a pessoa associada a essa transação
        [Required]
        [ForeignKey("Pessoa")]
        public long PessoaId { get; set; }

        // A propriedade de navegação que permite acessar os dados da pessoa associada a essa transação
        public required Pessoa Pessoa { get; init; }

        // Construtor padrão da classe, necessário para a criação de uma instância sem parâmetros
        public Transacao()
        {
        }

        // Construtor com parâmetros para inicializar todas as propriedades da classe
        // Este é útil para criar uma instância da transação com valores específicos
        public Transacao(long id, string descricao, double valor, DateTime dataHora, TransacaoTipo tipoTransacao, long pessoaId, Pessoa pessoa)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            DataHora = dataHora;
            TipoTransacao = tipoTransacao;
            PessoaId = pessoaId;
            Pessoa = pessoa;
        }

        public Transacao(string descricao, double valor, DateTime dataHora)
        {
            Descricao = descricao;
            Valor = valor;
            DataHora = dataHora;
        }
    }

}
