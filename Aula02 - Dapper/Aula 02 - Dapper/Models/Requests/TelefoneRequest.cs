namespace Aula_02___Dapper.Models.Requests;

public class TelefoneRequest
{
    public int? Id { get; set; }
    public string Numero { get; set; }
    public int Operadora { get; set; }
    public int Pessoa { get; set; }
}