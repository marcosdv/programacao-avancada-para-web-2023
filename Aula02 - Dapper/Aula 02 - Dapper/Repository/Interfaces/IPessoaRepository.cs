using Aula_02___Dapper.Models;
using Aula_02___Dapper.Models.Requests;

namespace Aula_02___Dapper.Repository.Interfaces;

public interface IPessoaRepository
{
    IEnumerable<Pessoa> BuscarTodos();
    Pessoa? BuscarPorId(int id);

    int Incluir(PessoaRequest request);
    int Alterar(PessoaRequest request);
    int Excluir(int id);
}