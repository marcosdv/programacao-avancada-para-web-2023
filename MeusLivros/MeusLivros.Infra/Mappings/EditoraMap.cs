using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeusLivros.Infra.Mappings;

public class EditoraMap : IEntityTypeConfiguration<Editora>
{
    public void Configure(EntityTypeBuilder<Editora> builder)
    {
        //Especificando o nome da tabela no banco de dados
        builder.ToTable("Editora");

        //Informando qual a Chave primaria
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id) //selecionando o campo ID
            .ValueGeneratedOnAdd()  //dizendo para somar o ID a cada novo registro
            .UseIdentityColumn();   //Marca a coluna como identidade sequencial

        builder.Property(x => x.Nome) //selecionando o campo Nome
            .IsRequired()             //Definindo como obrigatorio (NOT NULL)
            .HasColumnName("Nome")    //Informando o nome da coluna no banco
            .HasColumnType("VARCHAR") //Definindo o tipo de dados da coluna
            .HasMaxLength(50);        //Definindo tamanho do VARCHAR
    }
}