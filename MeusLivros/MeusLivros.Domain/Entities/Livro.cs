﻿namespace MeusLivros.Domain.Entities;

public class Livro : Entity
{
    #region Propriedades

    public string Nome { get; set; }
    public int EditoraId { get; set; }
    public Editora Editora { get; set; }

    #endregion

    #region Construtores

    public Livro() { }

    public Livro(string nome, int editoraId)
    {
        Nome = nome;
        EditoraId = editoraId;
    }

    public Livro(int id, string nome, int editoraId)
    {
        Id = id;
        Nome = nome;
        EditoraId = editoraId;
    }

    #endregion
}