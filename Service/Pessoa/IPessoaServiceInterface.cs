using ControleDeGastos.DTO.Pessoa;
using ControleDeGastos.Model;

namespace ControleDeGastos.Service.Pessoa
{
    public interface IPessoaServiceInterface
    {
        // Método para salvar uma nova pessoa no banco de dados
        Task<ResponseModel<List<PessoaModel>>> Save(PessoaSaveRequestDTO pessoaSaveRequestDTO);

    }
}
