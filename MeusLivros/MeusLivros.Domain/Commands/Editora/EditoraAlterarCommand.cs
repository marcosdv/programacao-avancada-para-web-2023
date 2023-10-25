using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands.Editora;

public class EditoraAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public EditoraAlterarCommand() { }

    public EditoraAlterarCommand(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome da editora deve ser informado!");
    }
}