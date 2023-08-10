namespace Aula_02___Dapper.Models;

public class Pessoa : Entidade
{
    public string Nome { get; set; }
    public IList<Telefone> Telefones { get; set; }

    public Pessoa()
    {
        Telefones = new List<Telefone>();
    }

    public Pessoa(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Telefones = new List<Telefone>();
    }

    public void addTelefone(Telefone telefone)
    {
        Telefones.Add(telefone);
    }
}