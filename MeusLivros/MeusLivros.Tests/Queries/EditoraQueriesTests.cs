using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Queries;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Queries;

[TestClass]
public class EditoraQueriesTests
{
    private IEnumerable<Editora> _editoras;

    public EditoraQueriesTests()
    {
        var repository = new MockEditoraRepository();
        _editoras = repository.BuscarTodos();
    }

    [TestMethod]
    public void AoRealizarUmaConsultaComIdExistenteDeveRetornarUmaEditora()
    {
        var result = _editoras.AsQueryable()
            .Where(EditoraQueries.BuscarPorId(1)).FirstOrDefault();

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void AoRealizarUmaConsultaComIdInexistenteDeveRetornarNulo()
    {
        var result = _editoras.AsQueryable()
            .Where(EditoraQueries.BuscarPorId(10)).FirstOrDefault();

        Assert.IsNull(result);
    }
}