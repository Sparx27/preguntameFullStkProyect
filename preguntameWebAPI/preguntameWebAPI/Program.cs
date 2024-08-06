using Microsoft.EntityFrameworkCore;
using preguntameWebAPI.Models;
using preguntameWebAPI.Repositories;
using preguntameWebAPI.Repositories.Interfaces;
using preguntameWebAPI.Services;
using preguntameWebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Paises
builder.Services.AddScoped<IPaiseRepository<Paise>, PaiseRepository>();
builder.Services.AddScoped<IPaiseService, PaiseService>();

//Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddDbContext<AskmedbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("askmedbConnection")));

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
