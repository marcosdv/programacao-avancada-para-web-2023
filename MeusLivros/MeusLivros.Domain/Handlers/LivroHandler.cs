using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Commands.Livro;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers.Interfaces;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Domain.Handlers;

public class LivroHandler :
    IHandler<LivroInserirCommand>,
    IHandler<LivroAlterarCommand>,
    IHandler<LivroExcluirCommand>
{
    private readonly ILivroRepository _repository;

    public LivroHandler(ILivroRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(LivroInserirCommand command)
    {
        //Fail Fast Validation
        command.Validar();
        if (command.isInvalida) //Verifica se os dados são validos
            return new CommandResult(false, "Dados do Livro incorretos", command.Notificacoes);

        //cria a classe para inserir no banco
        var livro = new Livro(command.Nome,command.IdEditora);

        //insere o livro no banco
        _repository.Inserir(livro);

        return new CommandResult(true, "Livro inserido", livro);
    }

    public ICommandResult Handle(LivroAlterarCommand command)
    {
        //Fail Fast Validation
        command.Validar();
        if (command.isInvalida) //Verifica se os dados são validos
            return new CommandResult(false, "Dados do livro incorretos", command.Notificacoes);

        //busca o livro que sera editado
        var livro = _repository.BuscarPorId(command.Id);

        //senao encontrar o livro, retorna erro
        if (livro == null)
            return new CommandResult(false, "Livro não encontrado", command.Notificacoes);

        //atualiza os dados da classe com o que veio do command
        livro.Nome = command.Nome;
        livro.EditoraId = command.IdEditora;

        //altera o livro no banco
        _repository.Alterar(livro);

        return new CommandResult(true, "Livro alterado", livro);
    }

    public ICommandResult Handle(LivroExcluirCommand command)
    {
        //Fail Fast Validation
        command.Validar();
        if (command.isInvalida) //Verifica se os dados são validos
            return new CommandResult(false, "Dados do Livro incorretos", command.Notificacoes);

        //busca o livro que sera editada
        var livro = _repository.BuscarPorId(command.Id);

        //senao encontrar o livro, retorna erro
        if (livro == null)
            return new CommandResult(false, "Livro não encontrado", command.Notificacoes);

        //exclui o livro no banco
        _repository.Excluir(livro);

        return new CommandResult(true, "Livro excluida", livro);
    }
}