using Aula_02___Dapper.Models;
using Aula_02___Dapper.Models.Requests;
using Aula_02___Dapper.Repository.Interfaces;
using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula_02___Dapper.Repository;

public class PessoaRepository : IPessoaRepository
{
    private const string connectionString =
        "Server=UNIALFA-SL04\\SQLEXPRESS;Database=AgendaDb;Trusted_Connection=True;Integrated Security=true;Encrypt=False;";

    public int Incluir(PessoaRequest request)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute("INSERT INTO TbPessoa (nome) VALUES (@nome)",
            new { nome = request.Nome });
    }

    public int Alterar(PessoaRequest request)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute("UPDATE TbPessoa SET nome = @nome WHERE id = @id",
            new { nome = request.Nome, id = request.Id });
    }

    public int Excluir(int id)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute("DELETE FROM TbPessoa WHERE id = @id", new { id });
    }

    public IEnumerable<Pessoa> BuscarTodos()
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Query<Pessoa>("SELECT * FROM TbPessoa");
    }

    public Pessoa? BuscarPorId(int id)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Query<Pessoa>("SELECT * FROM TbPessoa WHERE id = @id",
            new { id }).FirstOrDefault();
    }
}