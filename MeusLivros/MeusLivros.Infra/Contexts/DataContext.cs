using MeusLivros.Domain.Entities;
using MeusLivros.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MeusLivros.Infra.Contexts;

public class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }

    public DbSet<Editora> Editoras { get; set; }
    public DbSet<Livro> Livros { get; set; }

    //Adicioinar a configuracao dos Maps - Fluent Mapping
    //Evento executado quando inicial a modelagem do banco
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //aplicando as configuracoes feitas nos Mappings de Editora e Livro
        modelBuilder.ApplyConfiguration(new EditoraMap());
        modelBuilder.ApplyConfiguration(new LivroMap());

        //Opcao de usar comando SQL
        /*
        modelBuilder.Entity<EditoraLivroTotal>(x => x.ToSqlQuery(@"
            SELECT Editora.*, COUNT(Livro.Id) as TotalLivros
            FROM Editora
            INNER JOIN Livro ON Livro.EditoraId = Editora.Id
            GROUP BY Editor.Id, Editora.Nome
        "));
        */
    }
}