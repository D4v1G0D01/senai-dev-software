using MinhaApi.Repositories;
using MinhaApi.Services;

var builder = WebApplication.CreateBuilder(args); // Corrigido CreteBuilder -> CreateBuilder

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Corrigido AddEndpontsApiExplorer -> AddEndpointsApiExplorer
builder.Services.AddSwaggerGen();

// Registra o Repository
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// Registra a Service
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) // Corrigido Enviroment -> Environment
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Corrigido UserSwaggerUI -> UseSwaggerUI
}

app.MapControllers();
app.Run();