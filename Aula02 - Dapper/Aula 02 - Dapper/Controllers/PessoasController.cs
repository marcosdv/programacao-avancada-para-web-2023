using Aula_02___Dapper.Models.Requests;
using Aula_02___Dapper.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Aula_02___Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoasController : ControllerBase
{
    private readonly IPessoaRepository repository;
    private readonly ILogger<PessoasController> logger;

    public PessoasController(IPessoaRepository repo,
                             ILogger<PessoasController> log)
    {
        repository = repo;
        logger = log;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        try
        {
            logger.LogInformation("Executando BuscarTodos");

            var lista = repository.BuscarTodos().ToList();

            if (lista.IsNullOrEmpty())
            {
                logger.LogWarning("Não há dados para exibir");
                return NoContent();
            }

            return Ok(lista);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Adicionar(PessoaRequest request)
    {
        if (string.IsNullOrEmpty(request.Nome))
            return BadRequest("Campo nome é obrigatório!");

        try
        {
            return Ok(repository.Incluir(request));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Alterar(PessoaRequest request)
    {
        if (string.IsNullOrEmpty(request.Nome))
            return BadRequest("Campo nome é obrigatório!");

        try
        {
            return Ok(repository.Alterar(request));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        try
        {
            return Ok(repository.Excluir(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
