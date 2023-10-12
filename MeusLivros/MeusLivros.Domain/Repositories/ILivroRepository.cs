﻿using MeusLivros.Domain.Entities;

namespace MeusLivros.Domain.Repositories;

public interface ILivroRepository
{
    void Inserir(Livro livro);
    void Alterar(Livro livro);
    void Excluir(Livro livro);

    IEnumerable<Livro> BuscarTodos();
    Livro? BuscarPorId(int id);
}