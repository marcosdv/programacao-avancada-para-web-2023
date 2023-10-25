using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Contexts;
using MeusLivros.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//DI - Injecao de Dependencias

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

builder.Services.AddTransient<IEditoraRepository, EditoraRepository>();
builder.Services.AddTransient<ILivroRepository, LivroRepository>();

builder.Services.AddTransient<EditoraHandler, EditoraHandler>();
builder.Services.AddTransient<LivroHandler, LivroHandler>();

//DI - Injecao de Dependencias



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
