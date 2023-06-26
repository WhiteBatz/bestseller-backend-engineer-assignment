using Common.Api.MIddleware;
using Common.Db.Data;
using Communications.Extensions;
using DatabaseUpdaterService.Data;
using DatabaseUpdaterService.Data.Repositories;
using DatabaseUpdaterService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using PokemonService.Business;
using PokemonService.Business.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PokemonContext>(options => options.UseNpgsql(conn));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Service Dependencies
builder.Services.AddCommunicationDependencies();

// Add Handlers
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPokemonHandler, PokemonHandler>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
