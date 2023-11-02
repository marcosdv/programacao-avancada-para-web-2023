using MeusLivros.Domain.Commands.Editora;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class EditoraAlterarCommandTests
{
    [TestMethod]
    public void DadoUmComandoInvalidoDeveRetornarInvalido()
    {
        var command = new EditoraAlterarCommand() { Id = 0, Nome = "" };

        command.Validar();

        Assert.IsTrue(command.isInvalida);
    }

    [TestMethod]
    public void DadoUmComandoValidoDeveRetornarValido()
    {
        var command = new EditoraAlterarCommand() { Id = 1, Nome = "Teste" };

        command.Validar();

        Assert.IsTrue(command.isValida);
    }
}