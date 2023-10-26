using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeusLivros.Infra.Mappings;

public class LivroMap : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        //Especificando o nome da tabela no banco de dados
        builder.ToTable("Livro");

        //Informando qual a Chave primaria
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id) //selecionando o campo ID
            .ValueGeneratedOnAdd()  //dizendo para somar o ID a cada novo registro
            .UseIdentityColumn();   //Marca a coluna como identidade sequencial

        builder.Property(x => x.Nome) //selecionando o campo Nome
            .IsRequired()             //Definindo como obrigatorio (NOT NULL)
            .HasColumnName("Nome")    //Informando o nome da coluna no banco
            .HasColumnType("VARCHAR") //Definindo o tipo de dados da coluna
            .HasMaxLength(150);       //Definindo tamanho do VARCHAR

        //Criando o relacionamento com a Editora
        builder
            .HasOne(x => x.Editora) //Informando que o Livro possui uma Editora
            .WithMany(x => x.Livros) //E que uma Editora tem muitos Livros
            .HasConstraintName("FK_Livro_Editora");
    }
}