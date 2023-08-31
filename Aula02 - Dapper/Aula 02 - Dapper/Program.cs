using Aula_02___Dapper.Repository;
using Aula_02___Dapper.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//Adicionando a Injecao de Dependencias - DI
//builder.Services.AddSingleton<IPessoaRepository, PessoaRepository>();
//builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
builder.Services.AddTransient<ITelefoneRepository, TelefoneRepository>();



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
