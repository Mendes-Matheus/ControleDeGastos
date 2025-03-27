using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControleDeGastos.Model
{
    // Atributo que define o nome da tabela no banco de dados. Aqui, a classe é mapeada para a tabela "pessoa"
    [Table("pessoa")]
    public class PessoaModel
    {
        // Define a chave primária da entidade. O valor será gerado automaticamente pelo banco de dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // A propriedade "Nome" é obrigatória e representa o nome da pessoa
        [Required]
        public string Nome { get; set; } = string.Empty;

        // A propriedade "Idade" é obrigatória e representa a idade da pessoa
        [Required]
        public int Idade { get; set; }

        // As propriedades Receitas, Despesas, Mesada, Saldo e Transacoes são ignoradas na serialização JSON
        // Elas representam informações financeiras da pessoa - receitas, despesas, mesada e saldo
        [JsonIgnore]
        public double Receitas { get; set; } = 0.0;

        [JsonIgnore]
        public double Despesas { get; set; } = 0.0;

        [JsonIgnore]
        public double Mesada { get; set; } = 0.0;

        [JsonIgnore]
        public double Saldo { get; set; } = 0.0;

        [JsonIgnore]
        public ICollection<TransacaoModel>? Transacoes { get; set; }

        // Construtor padrão da classe, necessário para a criação de uma instância sem parâmetros
        public PessoaModel()
        {
        }

        // Construtor com parâmetros que inicializa todas as propriedades da classe
        // Este é útil para criar uma instância da pessoa com valores específicos
        public PessoaModel(long id, string nome, int idade, double receitas, double despesas, double mesada, double saldo, ICollection<TransacaoModel>? transacoes)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Receitas = receitas;
            Despesas = despesas;
            Mesada = mesada;
            Saldo = saldo;
            Transacoes = transacoes;
        }

    }
}
