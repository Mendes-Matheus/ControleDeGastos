using ControleDeGastos.Data;
using ControleDeGastos.DTO.Pessoa;
using ControleDeGastos.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Service.Pessoa
{
    // Classe responsável por manipular as operações relacionadas à entidade Pessoa
    public class PessoaService : IPessoaServiceInterface
    {
        // Contexto do banco de dados, necessário para realizar operações no banco
        private readonly AppDbContext _context;

        // Construtor que injeta a dependência do contexto do banco
        public PessoaService(AppDbContext context)
        {
            _context = context;
        }

        // Método para salvar uma nova pessoa no banco de dados
        public async Task<ResponseModel<List<PessoaModel>>> Save(PessoaSaveRequestDTO pessoaSaveRequestDTO)
        {
            try
            {
                // Cria uma nova instância de PessoaModel a partir dos dados fornecidos no DTO
                var pessoa = new PessoaModel()
                {
                    Nome = pessoaSaveRequestDTO.Nome,
                    Idade = pessoaSaveRequestDTO.Idade
                };

                // Adiciona a nova pessoa ao contexto do banco
                _context.Add(pessoa);

                // Salva as mudanças no banco de dados de forma assíncrona
                await _context.SaveChangesAsync();


                // Recupera a lista atualizada de todas as pessoas no banco
                var pessoaa = await _context.Pessoas.ToListAsync();

                // Retorna uma resposta contendo a lista de pessoas e uma mensagem de sucesso
                return new ResponseModel<List<PessoaModel>>
                {
                    Dados = pessoaa,
                    Mensagem = "Pessoa salva com sucesso!"
                };

            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro, retorna uma resposta com a mensagem de erro
                return new ResponseModel<List<PessoaModel>>
                {
                    Mensagem = ex.Message,
                    Status = false
                };
            }
        }

        // Método para encontrar uma pessoa no banco de dados pelo ID
        public async Task<ResponseModel<object>> FindById(int idPessoa)
        {
            try
            {
                // Busca a pessoa no banco de dados pelo ID fornecido
                var pessoa = await _context.Pessoas.FirstOrDefaultAsync(pessoaBanco => pessoaBanco.Id == idPessoa);
                var resposta = new ResponseModel<object>();

                // Verifica se a pessoa foi encontrada
                if (pessoa == null)
                {
                    resposta.Mensagem = "Nenhuma pessoa localizada com esse id!"; // Mensagem de erro se a pessoa não for encontrada
                    resposta.Status = false; // Indica que a operação falhou
                }
                else
                {
                    // Se a pessoa for menor de idade, cria um DTO específico para pessoas menores
                    if (pessoa.Idade < 18)
                    {
                        resposta.Dados = new PessoaMenorComTotaisDTO(
                            pessoa.Id,
                            pessoa.Nome,
                            pessoa.Idade,
                            pessoa.Mesada,
                            pessoa.Despesas,
                            pessoa.Saldo
                        );
                    }
                    else
                    {
                        // Se a pessoa for maior de idade, cria um DTO específico para pessoas maiores
                        resposta.Dados = new PessoaComTotaisDTO(
                            pessoa.Id,
                            pessoa.Nome,
                            pessoa.Idade,
                            pessoa.Receitas,
                            pessoa.Despesas,
                            pessoa.Saldo
                        );
                    }

                    resposta.Mensagem = "Pessoa Localizada!"; // Mensagem de sucesso
                    resposta.Status = true; // Indica que a operação foi bem-sucedida
                }

                return resposta; // Retorna a resposta com os dados da pessoa ou mensagem de erro
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro, retorna uma resposta com a mensagem de erro
                return new ResponseModel<object>
                {
                    Mensagem = ex.Message,
                    Status = false // Indica que a operação falhou
                };
            }
        }


        // Método para buscar todas as pessoas no banco de dados
        public async Task<ResponseModel<List<object>>> FindAll()
        {
            try
            {
                // Recupera todas as pessoas no banco de dados
                var pessoas = await _context.Pessoas.ToListAsync();
                var resposta = new ResponseModel<List<object>>();

                // Lista para armazenar as pessoas formatadas
                var pessoasFormatadas = new List<object>();

                foreach (var pessoa in pessoas)
                {
                    if (pessoa.Idade < 18)
                    {
                        pessoasFormatadas.Add(new PessoaMenorComTotaisDTO(
                            pessoa.Id,
                            pessoa.Nome,
                            pessoa.Idade,
                            pessoa.Mesada,
                            pessoa.Despesas,
                            pessoa.Saldo
                        ));
                    }
                    else
                    {
                        pessoasFormatadas.Add(new PessoaComTotaisDTO(
                            pessoa.Id,
                            pessoa.Nome,
                            pessoa.Idade,
                            pessoa.Receitas,
                            pessoa.Despesas,
                            pessoa.Saldo
                        ));
                    }
                }

                // Retorna uma resposta com a lista de todas as pessoas formatadas
                resposta.Dados = pessoasFormatadas;
                return resposta;

            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro, retorna uma resposta com a mensagem de erro
                return new ResponseModel<List<object>>
                {
                    Mensagem = ex.Message,
                    Status = false
                };
            }
        }

        public PessoaComTotaisDTO MapPessoaModelToDTO(PessoaModel pessoaModel)
        {
            // Retorna uma nova instância de PessoaComTotaisDTO com os valores do PessoaModel
            return new PessoaComTotaisDTO(
                pessoaModel.Id,
                pessoaModel.Nome,
                pessoaModel.Idade,
                pessoaModel.Receitas,
                pessoaModel.Despesas,
                pessoaModel.Saldo
            );
        }

        public PessoaMenorComTotaisDTO MapPessoaMenorModelToDTO(PessoaModel pessoaModel)
        {
            // Retorna uma nova instância de PessoaMenorComTotaisDTO com os valores do PessoaModel
            return new PessoaMenorComTotaisDTO(
                pessoaModel.Id,
                pessoaModel.Nome,
                pessoaModel.Idade,
                pessoaModel.Mesada,
                pessoaModel.Despesas,
                pessoaModel.Saldo
            );
        }



    }
}
