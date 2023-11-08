using MeusLivros.Domain.Entities;
using System.Linq.Expressions;

namespace MeusLivros.Domain.Queries;

public class EditoraQueries
{
    public static Expression<Func<Editora, bool>> BuscarPorId(int codigo)
    {
        return x => x.Id == codigo; //WHERE Editora.Id == codigo
    }
}