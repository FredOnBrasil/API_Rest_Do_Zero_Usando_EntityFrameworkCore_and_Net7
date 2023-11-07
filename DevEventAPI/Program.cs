using DevEventAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevEventAPI",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Fred Aguiar",
            Email = "fredon.analista@gmail.com"
        }
    });

    const string xmlFile = "DevEventAPI.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    o.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//força a manter a documentação independente do ambiente em que for publicado --- antiga config acima.
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
