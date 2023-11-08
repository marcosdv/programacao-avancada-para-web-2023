using MeusLivros.Domain.Commands.Editora;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class EditoraInserirCommandTests
{
    [TestMethod]
    public void DadoUmComandoInvalidoDeveRetornarInvalido()
    {
        var command = new EditoraInserirCommand() { Nome = "" };

        command.Validar();

        Assert.IsTrue(command.isInvalida);
    }

    [TestMethod]
    public void DadoUmComandoValidoDeveRetornarValido()
    {
        var command = new EditoraInserirCommand() { Nome = "Teste" };

        command.Validar();

        Assert.IsTrue(command.isValida);
    }
}
