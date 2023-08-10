using Aula_02___Dapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Aula_02___Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    private const string connectionString =
        "Server=MDV-NOTE;Database=AgendaDb;Trusted_Connection=True;Integrated Security=true;Encrypt=False;";

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
}