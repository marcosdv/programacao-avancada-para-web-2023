using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands.Livro;

public class LivroExcluirCommand : Notificavel, ICommand
{
    public int Id { get; set; }

    public LivroExcluirCommand() { }

    public LivroExcluirCommand(int id)
    {
        Id = id;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");
    }
}