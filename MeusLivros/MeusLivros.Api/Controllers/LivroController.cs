using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Livro;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroRepository _repository;
    private readonly LivroHandler _handler;

    public LivroController(ILivroRepository repository, LivroHandler handler)
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
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public CommandResult Inserir(LivroInserirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [HttpPut]
    public CommandResult Alterar(LivroAlterarCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [HttpDelete]
    public CommandResult Excluir(LivroExcluirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }
}
