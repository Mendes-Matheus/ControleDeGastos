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
        public async Task<ResponseModel<PessoaModel>> FindById(int idPessoa)
        {
            try
            {
                // Busca a pessoa no banco com o ID fornecido
                var pessoa = await _context.Pessoas.FirstOrDefaultAsync(pessoaBanco => pessoaBanco.Id == idPessoa);

                // Retorna uma resposta com a pessoa encontrada, ou uma mensagem caso não tenha sido encontrada
                var resposta = pessoa == null
                    ? new ResponseModel<PessoaModel> { Mensagem = "Nenhuma pessoa localizada com esse id!" }
                    : new ResponseModel<PessoaModel> { Dados = pessoa, Mensagem = "Pessoa Localizada!" };

                return resposta;


            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro, retorna uma resposta com a mensagem de erro
                return new ResponseModel<PessoaModel>
                {
                    Mensagem = ex.Message,
                    Status = false
                };
            }
        }

        // Método para buscar todas as pessoas no banco de dados
        public async Task<ResponseModel<List<PessoaModel>>> FindAll()
        {
            try
            {
                // Recupera todas as pessoas no banco de dados
                var pessoas = await _context.Pessoas.ToListAsync();

                // Retorna uma resposta com a lista de todas as pessoas
                return new ResponseModel<List<PessoaModel>>
                {
                    Dados = pessoas
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

    }
}
