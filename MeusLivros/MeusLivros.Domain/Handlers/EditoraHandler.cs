using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers.Interfaces;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Domain.Handlers;

public class EditoraHandler :
    IHandler<EditoraInserirCommand>,
    IHandler<EditoraAlterarCommand>,
    IHandler<EditoraExcluirCommand>
{
    private readonly IEditoraRepository _repository;

    public EditoraHandler(IEditoraRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(EditoraInserirCommand command)
    {
        //Fail Fast Validation
        command.Validar();
        if (command.isInvalida) //Verifica se os dados são validos
            return new CommandResult(false, "Dados da editora incorretos", command.Notificacoes);

        //cria a classe para inserir no banco
        var editora = new Editora(command.Nome);

        //insere a editora no banco
        _repository.Inserir(editora);

        return new CommandResult(true, "Editora inserida", editora);
    }

    public ICommandResult Handle(EditoraAlterarCommand command)
    {
        //Fail Fast Validation
        command.Validar();
        if (command.isInvalida) //Verifica se os dados são validos
            return new CommandResult(false, "Dados da editora incorretos", command.Notificacoes);

        //busca a editora que sera editada
        var editora = _repository.BuscarPorId(command.Id);

        //senao encontrar a editora, retorna erro
        if (editora == null)
            return new CommandResult(false, "Editora não encontrada", command.Notificacoes);

        //atualiza os dados da classe com o que veio do command
        editora.alterarNome(command.Nome);

        //altera a editora no banco
        _repository.Alterar(editora);

        return new CommandResult(true, "Editora alterada", editora);
    }

    public ICommandResult Handle(EditoraExcluirCommand command)
    {
        //Fail Fast Validation
        command.Validar();
        if (command.isInvalida) //Verifica se os dados são validos
            return new CommandResult(false, "Dados da editora incorretos", command.Notificacoes);

        //busca a editora que sera editada
        var editora = _repository.BuscarPorId(command.Id);

        //senao encontrar a editora, retorna erro
        if (editora == null)
            return new CommandResult(false, "Editora não encontrada", command.Notificacoes);

        //exclui a editora no banco
        _repository.Excluir(editora);

        return new CommandResult(true, "Editora excluida", editora);
    }
}