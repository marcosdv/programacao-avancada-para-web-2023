namespace MeusLivros.Domain.Entities;

public class Editora : Entity
{
    #region Propriedades

    public string Nome { get; private set; }
    public IList<Livro> Livros { get; private set; }

    #endregion

    #region Construtores

    /// <summary>
    /// Construtor que recebe somente o nome (usando para insert)
    /// </summary>
    /// <param name="nome"></param>
    public Editora(string nome)
    {
        Nome = nome;
        Livros = new List<Livro>();
    }

    /// <summary>
    /// Construtor que recebe id e nome (usando para update)
    /// </summary>
    /// <param name="id"></param>
    /// <param name="nome"></param>
    public Editora(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Livros = new List<Livro>();
    }

    #endregion

    #region Metodos

    public void addLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public void alterarNome(string nome)
    {
        Nome = nome;
    }

    #endregion
}