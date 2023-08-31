using Aula_02___Dapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Aula_02___Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    private const string connectionString =
        "Server=UNIALFA-SL04\\SQLEXPRESS;Database=AgendaDb;Trusted_Connection=True;Integrated Security=true;Encrypt=False;";

    [HttpGet]
    public IActionResult BuscarTodas()
    {
        var operadoras = new List<Operadora>();

        using var connection = new SqlConnection(connectionString);

        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT * FROM TbOperadora";

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operadora = new Operadora(reader.GetInt32(0), reader.GetString(1));
            operadoras.Add(operadora);
        }

        connection.Close();
        
        return Ok(operadoras);
    }

    [HttpPost]
    public IActionResult Incluir(Operadora operadora)
    {
        if (string.IsNullOrEmpty(operadora.Nome))
            return BadRequest("Nome da operadora deve ser informado!");

        using var connection = new SqlConnection(connectionString);
        connection.Open();
        
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;

        command.CommandText = "INSERT INTO TbOperadora (Nome) VALUES (@Nome)";
        command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = operadora.Nome;

        int linhasAfetadas = command.ExecuteNonQuery();

        return Ok("Linhas afetadas: " + linhasAfetadas);
    }

    [HttpPut("{id}")]
    public IActionResult Alterar(int id, Operadora operadora)
    {
        if (string.IsNullOrEmpty(operadora.Nome))
            return BadRequest("Nome da operadora deve ser informado!");

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;

        command.CommandText = "UPDATE TbOperadora SET Nome = @Nome WHERE Id = @Id";
        command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = operadora.Nome;
        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        int linhasAfetadas = command.ExecuteNonQuery();

        return Ok("Linhas afetadas: " + linhasAfetadas);
    }

    [HttpDelete("{id}")]
    public IActionResult Apagar(int id)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;

        command.CommandText = "DELETE FROM TbOperadora WHERE Id = @Id";
        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        int linhasAfetadas = command.ExecuteNonQuery();

        return Ok("Linhas afetadas: " + linhasAfetadas);
    }
}