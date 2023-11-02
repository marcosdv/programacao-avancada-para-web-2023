using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Handlers;

[TestClass]
public class EditoraHandlerTests
{
    private readonly IEditoraRepository _repository;
    private readonly EditoraHandler _handler;

    public EditoraHandlerTests()
    {
        _repository = new MockEditoraRepository();
        _handler = new EditoraHandler(_repository);
    }

    #region | Inserir Tests |

    [TestMethod]
    public void DadoUmComandoDeInserirValidoDeveRetornarSucessoTrue()
    {
        var command = new EditoraInserirCommand("Teste");

        var result = (CommandResult)_handler.Handle(command);

        Assert.IsTrue(result.Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoDeInserirInvalidoDeveRetornarSucessoFalse()
    {
        var command = new EditoraInserirCommand("");

        var result = (CommandResult)_handler.Handle(command);

        Assert.IsFalse(result.Sucesso);
    }

    #endregion

    #region | Alterar Tests |

    [TestMethod]
    public void DadoUmComandoDeAlterarValidoDeveRetornarSucessoTrue()
    {
        var command = new EditoraAlterarCommand(1, "Teste");

        var result = (CommandResult)_handler.Handle(command);

        Assert.IsTrue(result.Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoDeAlterarInvalidoDeveRetornarSucessoFalse()
    {
        var command = new EditoraAlterarCommand(0, "");

        var result = (CommandResult)_handler.Handle(command);

        Assert.IsFalse(result.Sucesso);
    }

    #endregion

    #region | Excluir Tests |

    [TestMethod]
    public void DadoUmComandoDeExcluirValidoDeveRetornarSucessoTrue()
    {
        var command = new EditoraExcluirCommand(1);

        var result = (CommandResult)_handler.Handle(command);

        Assert.IsTrue(result.Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoDeExcluirInvalidoDeveRetornarSucessoFalse()
    {
        var command = new EditoraExcluirCommand(0);

        var result = (CommandResult)_handler.Handle(command);

        Assert.IsFalse(result.Sucesso);
    }

    #endregion
}