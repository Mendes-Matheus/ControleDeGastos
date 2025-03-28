using ControleDeGastos.DTO.Transacao;
using ControleDeGastos.Model;
using ControleDeGastos.Data;
using Microsoft.EntityFrameworkCore;
using System;
using ControleDeGastos.Service.Pessoa;

namespace ControleDeGastos.Service.Transacao
{
    public class TransacaoService : ITransacaoServiceInterface
    {
        private readonly AppDbContext _context;
        private readonly IPessoaServiceInterface _pessoaService;

        public TransacaoService(AppDbContext context, IPessoaServiceInterface pessoaService)
        {
            _context = context;
            _pessoaService = pessoaService;
        }

        // Salva uma transação
        public async Task<ResponseModel<List<TransacaoModel>>> Save(long pessoaId, TransacaoRequestDTO transacaoRequestDTO)
        {
            try
            {
                // Verifica se a pessoa existe
                var pessoa = await _context.Pessoas.FindAsync(pessoaId);
                if (pessoa == null)
                {
                    return new ResponseModel<List<TransacaoModel>>
                    {
                        Mensagem = "Pessoa não encontrada.",
                        Status = false
                    };
                }

                // Cria uma nova instância de TransacaoModel a partir do DTO
                var transacao = new TransacaoModel(pessoa)
                {
                    Valor = transacaoRequestDTO.valor,
                    DataHora = DateTime.Now,
                    Descricao = transacaoRequestDTO.descricao,
                    TipoTransacao = transacaoRequestDTO.tipo,
                    Pessoa = pessoa
                };


                // Verifica a idade da pessoa
                if (pessoa.Idade < 18 && transacao.TipoTransacao == TransacaoTipo.RECEITA)
                {
                    return new ResponseModel<List<TransacaoModel>>
                    {
                        Mensagem = "Menor de idade não pode realizar receitas.",
                        Status = false
                    };
                }

                // Verifica se a pessoa tem saldo suficiente para a despesa
                if (pessoa.Saldo < transacao.Valor && transacao.TipoTransacao == TransacaoTipo.DESPESA)
                {
                    return new ResponseModel<List<TransacaoModel>>
                    {
                        Mensagem = "Saldo insuficiente.",
                        Status = false
                    };
                }

                // Atualiza o saldo da pessoa
                await _pessoaService.UpdateSaldo(pessoaId, transacao);

                // Salva a transação
                await _context.Transacoes.AddAsync(transacao);
                await _context.SaveChangesAsync();

                // Cria o modelo de resposta
                return new ResponseModel<List<TransacaoModel>>
                {
                    Status = true,
                    Dados = new List<TransacaoModel> { transacao },
                    Mensagem = "Transação salva com sucesso."
                };
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro, retorna uma resposta com a mensagem de erro
                return new ResponseModel<List<TransacaoModel>>
                {
                    Mensagem = ex.Message,
                    Status = false
                };
            }
        }

        // Retorna todas as transações registradas
        public async Task<ResponseModel<List<TransacaoModel>>> GetAll()
        {
            try
            {
                // Recupera todas as transações do banco de dados, incluindo os dados da pessoa associada
                var transacoes = await _context.Transacoes
                    .Include(t => t.Pessoa)  // Garante que os dados da pessoa relacionada sejam carregados
                    .ToListAsync();

                // Retorna a lista de transações em um objeto de resposta
                return new ResponseModel<List<TransacaoModel>>
                {
                    Dados = transacoes,
                    Mensagem = "Todas as transações recuperadas com sucesso",
                    Status = true
                };
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna uma resposta com a mensagem de exceção
                return new ResponseModel<List<TransacaoModel>>
                {
                    Mensagem = ex.Message,
                    Status = false
                };
            }
        }

        
    }
}