using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EditoraController : ControllerBase
{
    private readonly IEditoraRepository _repository;
    private readonly EditoraHandler _handler;

    public EditoraController(IEditoraRepository repository, EditoraHandler handler)
    {
        _repository = repository;
        _handler = handler;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        return Ok(_repository.BuscarTodos());
    }

    [HttpGet("id")]
    public IActionResult BuscarPorId(int id)
    {
        var result = _repository.BuscarPorId(id);
        return result != null ? Ok(result) : NoContent();
    }

    [HttpPost]
    public CommandResult Inserir(EditoraInserirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [HttpPut]
    public CommandResult Alterar(EditoraAlterarCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [HttpDelete]
    public CommandResult Excluir(EditoraExcluirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }
}