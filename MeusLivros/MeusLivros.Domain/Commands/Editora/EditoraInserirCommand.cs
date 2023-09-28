using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands.Editora;

public class EditoraInserirCommand : Notificavel, ICommand
{
    public string Nome { get; set; }

    public EditoraInserirCommand() { }

    public EditoraInserirCommand(string nome)
    {
        Nome = nome;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome da editora deve ser informado!");
    }
}