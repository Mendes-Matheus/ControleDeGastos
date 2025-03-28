using ControleDeGastos.Data;
using ControleDeGastos.DTO.Transferencia;
using ControleDeGastos.Model;
using ControleDeGastos.Service.Pessoa;
using ControleDeGastos.Service.Transacao;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Service.Transferencia
{
    public class TransferenciaService : ITransferenciaServiceInterface
    {

        private readonly AppDbContext _context;
        private readonly ITransacaoServiceInterface _transacaoService;
        private readonly ITransferenciaServiceInterface _transferenciaService;

        public TransferenciaService(AppDbContext context, ITransferenciaServiceInterface transferenciaService, ITransacaoServiceInterface transacaoService)
        {
            _context = context;
            _transacaoService = transacaoService;
            _transferenciaService = transferenciaService;
        }




        public async Task<ResponseModel<List<TransferenciaResponseDTO>>> Transferir(long remetenteId, long destinatarioId, double valor)
        {
            try
            {
                // Verifica se o remetente existe
                var remetente = await _context.Pessoas.FindAsync(remetenteId);
                if (remetente == null)
                {
                    return new ResponseModel<List<TransferenciaResponseDTO>>
                    {
                        Mensagem = "Remetente não encontrado.",
                        Status = false
                    };
                }

                // Verifica se o destinatário existe
                var destinatario = await _context.Pessoas.FindAsync(destinatarioId);
                if (destinatario == null)
                {
                    return new ResponseModel<List<TransferenciaResponseDTO>>
                    {
                        Mensagem = "Destinatário não encontrado.",
                        Status = false
                    };
                }

                // Validações: idade mínima e saldo suficiente
                if (remetente.Idade < 18 || destinatario.Idade < 18)
                {
                    return new ResponseModel<List<TransferenciaResponseDTO>>
                    {
                        Mensagem = "Transferência não permitida para menores de idade.",
                        Status = false
                    };
                }

                if (remetente.Saldo < valor)
                {
                    return new ResponseModel<List<TransferenciaResponseDTO>>
                    {
                        Mensagem = "Saldo insuficiente para a transferência.",
                        Status = false
                    };
                }

                // Atualiza os saldos das pessoas envolvidas
                remetente.Saldo -= valor;
                destinatario.Saldo += valor;

                // Cria a transação de transferência
                var transferencia = new TransferenciaModel(remetente.Nome, destinatario.Nome)
                {
                    Descricao = $"Transferência de {remetente.Nome} para {destinatario.Nome}",
                    Valor = valor,
                    DataHora = DateTime.Now,
                    TipoTransacao = TransacaoTipo.DESPESA,
                    PessoaId = remetente.Id,
                    Pessoa = remetente
                };

                // Adiciona a transferência no banco de dados
                await _context.Transacoes.AddAsync(transferencia);
                await _context.SaveChangesAsync();

                // Monta a resposta
                var resposta = new List<TransferenciaResponseDTO>
        {
            new TransferenciaResponseDTO(
                transferencia.Descricao,
                transferencia.Remetente,
                transferencia.Destinatario,
                transferencia.DataHora.ToString("yyyy-MM-dd HH:mm:ss"),
                transferencia.Valor
            )
        };

                return new ResponseModel<List<TransferenciaResponseDTO>>
                {
                    Status = true,
                    Dados = resposta,
                    Mensagem = "Transferência realizada com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<TransferenciaResponseDTO>>
                {
                    Mensagem = ex.Message,
                    Status = false
                };
            }
        }

    }
}
