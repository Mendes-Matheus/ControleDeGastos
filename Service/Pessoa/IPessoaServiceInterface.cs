using ControleDeGastos.DTO.Pessoa;
using ControleDeGastos.Model;

namespace ControleDeGastos.Service.Pessoa
{
    public interface IPessoaServiceInterface
    {
        // Método para salvar uma nova pessoa no banco de dados
        Task<ResponseModel<List<PessoaModel>>> Save(PessoaSaveRequestDTO pessoaSaveRequestDTO);

        // Método para encontrar uma pessoa no banco de dados pelo ID
        Task<ResponseModel<PessoaModel>> FindById(int idAutor);


    }
}
