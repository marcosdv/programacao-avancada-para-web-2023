using MeusLivros.Domain.Commands.Editora;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class EditoraExcluirCommandTests
{
    [TestMethod]
    public void DadoUmComandoInvalidoDeveRetornarInvalido()
    {
        var command = new EditoraExcluirCommand() { Id = 0 };

        command.Validar();

        Assert.IsTrue(command.isInvalida);
    }

    [TestMethod]
    public void DadoUmComandoValidoDeveRetornarValido()
    {
        var command = new EditoraExcluirCommand() { Id = 1 };

        command.Validar();

        Assert.IsTrue(command.isValida);
    }
}
