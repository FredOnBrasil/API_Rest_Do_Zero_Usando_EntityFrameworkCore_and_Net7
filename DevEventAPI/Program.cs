using DevEventAPI.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Persiste o EventosDbContext em memória para uso na aplicação sem uso do EF(entity framework)
//builder.Services.AddSingleton<EventosDbContext>();

//aqui persistimos os banco em memoria com o uso do EF(entity framework)
builder.Services.AddDbContext<EventosDbContext>(
    o => o.UseInMemoryDatabase("BancoDadosTesteEmMemoria")
    ); 

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
