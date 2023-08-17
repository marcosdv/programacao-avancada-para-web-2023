namespace Aula_02___Dapper.Models;

public class Operadora : Entidade
{
    public string Nome { get; set; }

    public Operadora(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}