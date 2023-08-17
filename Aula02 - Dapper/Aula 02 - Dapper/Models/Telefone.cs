namespace Aula_02___Dapper.Models;

public class Telefone : Entidade
{
    public string Numero { get; set; }
    public Operadora Operadora { get; set; }

    public Telefone() { }

    public Telefone(int id, string numero, Operadora operadora)
    {
        Id = id;
        Numero = numero;
        Operadora = operadora;
    }
}