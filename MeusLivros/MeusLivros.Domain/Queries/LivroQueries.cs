using MeusLivros.Domain.Entities;
using System.Linq.Expressions;

namespace MeusLivros.Domain.Queries;

public class LivroQueries
{
    public static Expression<Func<Livro, bool>> BuscarTodos(Editora editora)
    {
        //return x => x.Editora.Id == editora.Id; //WHERE livro.editoraId == editora.id
        return x => x.Editora == editora;
    }

    public static Expression<Func<Livro, bool>> BuscarPorId(int codigo, Editora editora)
    {
        //WHERE livro.id == codigo AND livro.editoraId == editora.id
        return x => x.Id == codigo && x.Editora == editora;
    }
}