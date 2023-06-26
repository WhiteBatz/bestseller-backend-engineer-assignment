using Common.Api.MIddleware;
using Common.Db.Data;
using DatabaseUpdaterService.Data;
using DatabaseUpdaterService.Data.Repositories;
using DatabaseUpdaterService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TranslationService.Business;
using TranslationService.Business.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PokemonContext>(options => options.UseNpgsql(conn));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Handlers
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITranslationHandler, TranslationHandler>();
builder.Services.AddScoped<ITranslationRepository, TranslationRepository>();   


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
