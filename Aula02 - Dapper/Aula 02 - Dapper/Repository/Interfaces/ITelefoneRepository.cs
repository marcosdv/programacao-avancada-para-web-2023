using Aula_02___Dapper.Models;
using Aula_02___Dapper.Models.Requests;

namespace Aula_02___Dapper.Repository.Interfaces;

public interface ITelefoneRepository
{
    IEnumerable<Telefone> BuscarTodos();
    Telefone? BuscarPorId(int id);
    
    int Incluir(TelefoneRequest request);
    int Alterar(TelefoneRequest request);
    int Excluir(int id);
}