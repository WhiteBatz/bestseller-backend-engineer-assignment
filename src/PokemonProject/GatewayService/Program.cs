using GatewayService.Business;
using GatewayService.Business.Interfaces;
using Communications.Extensions;
using Common.Api.MIddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add service dependencies
builder.Services.AddCommunicationDependencies();

// Add Handlers
builder.Services.AddScoped<IPokemonHandler, PokemonHandler>();
builder.Services.AddScoped<ITranslationHandler, TranslationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
