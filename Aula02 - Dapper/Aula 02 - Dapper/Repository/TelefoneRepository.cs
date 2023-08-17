using Aula_02___Dapper.Models;
using Aula_02___Dapper.Models.Requests;
using Aula_02___Dapper.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula_02___Dapper.Repository;

public class TelefoneRepository : ITelefoneRepository
{
    private const string connectionString =
        "Server=UNIALFA-SL04\\SQLEXPRESS;Database=AgendaDb;Trusted_Connection=True;Integrated Security=true;Encrypt=False;";

    public int Incluir(TelefoneRequest request)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute(@"
            INSERT INTO TbTelefone (numero, operadoraId, pessoaId)
              VALUES (@numero, @operadoraId, @pessoaId)",
            new {
                numero = request.Numero,
                operadoraId = request.Operadora,
                pessoaId = request.Pessoa
            }
        );
    }
    
    public int Alterar(TelefoneRequest request)
     {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute(@"
            UPDATE TbTelefone SET
                numero = @numero, operadoraId = @operadoraId, pessoaId = @pessoaId
            WHEHE Id = @id",
            new {
                id = request.Id,
                numero = request.Numero,
                operadoraId = request.Operadora,
                pessoaId = request.Pessoa
            }
        );
    }

    public int Excluir(int id)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute("DELETE FROM TbTelefone WHEHE Id = @id", new { id });
    }

    public IEnumerable<Telefone> BuscarTodos()
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Query<Telefone, Operadora, Telefone>(@"
            SELECT * FROM TbTelefone T
            INNER JOIN TbOperadora O ON O.id = T.operadoraId",
            (telefone, operadora) => {
                telefone.Operadora = operadora;
                return telefone;
            }
        );
    }

    public Telefone? BuscarPorId(int id)
    {
        using var connection = new SqlConnection(connectionString);

        var lista = connection.Query<Telefone, Operadora, Telefone>(@"
            SELECT * FROM TbTelefone T
            INNER JOIN TbOperadora O ON O.id = T.operadoraId
            WHERE id = @id",
            (telefone, operadora) => {
                telefone.Operadora = operadora;
                return telefone;
            },
            new { id }
        );

        return lista.FirstOrDefault();
    }
}