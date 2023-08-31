using Aula_02___Dapper.Models.Requests;
using Aula_02___Dapper.Repository;
using Aula_02___Dapper.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Aula_02___Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TelefonesController : ControllerBase
{
    private readonly ITelefoneRepository _repository;
    private readonly ILogger<TelefonesController> _logger;

    public TelefonesController(ITelefoneRepository repository,
                               ILogger<TelefonesController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        try
        {
            var lista = _repository.BuscarTodos();
            return lista.IsNullOrEmpty() ? NoContent() : Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Adicionar(TelefoneRequest request)
    {
        try {
            return Ok(_repository.Incluir(request));
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Alterar(TelefoneRequest request)
    {
        try {
            return Ok(_repository.Alterar(request));
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        try {
            return Ok(_repository.Excluir(id));
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}