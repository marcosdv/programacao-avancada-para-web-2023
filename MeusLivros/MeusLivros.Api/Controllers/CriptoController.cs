using MeusLivros.Domain.Config;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CriptoController : ControllerBase
{
    private readonly Criptografia _criptografia;

    public CriptoController()
    {
        _criptografia = new Criptografia();
    }

    [HttpGet("AES/Cripto/{texto}")]
    public string CriptografarAES(string texto)
    {
        return _criptografia.AesEncrypt(texto);
    }

    [HttpGet("AES/Decripto/{texto}")]
    public string DecriptografarAES(string texto)
    {
        return _criptografia.AesDecrypt(texto);
    }

    [HttpGet("MD5/Cripto/{texto}")]
    public string CriptografarMD5(string texto)
    {
        return _criptografia.MD5Encrypt(texto);
    }
}