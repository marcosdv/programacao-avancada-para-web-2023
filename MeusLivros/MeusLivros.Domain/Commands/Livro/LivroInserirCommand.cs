using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands.Livro;

public class LivroInserirCommand : Notificavel, ICommand
{
    public string Nome { get; set; }
    public int IdEditora { get; set; }

    public LivroInserirCommand() { }

    public LivroInserirCommand(string nome, int idEditora)
    {
        Nome = nome;
        IdEditora = idEditora;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome do livro deve ser informado!");

        if (IdEditora <= 0)
            AdicionarNotificacao("Código da editora é inválido");
    }
}