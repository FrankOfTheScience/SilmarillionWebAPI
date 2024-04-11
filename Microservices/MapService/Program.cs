using MapService;
using MapService.Models;
using MapService.Repository;
using MongoDB.Driver;
using System.Text.Json.Serialization;
using JwtAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);
var configurations = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

var dbClient = Utilities.InitializeMongoClient(configurations);
var db = Utilities.InitializeMongoDatabase(dbClient);

builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoClient>(dbClient);
builder.Services.AddSingleton(db.GetCollection<PointOfInterestNode>("pointOfInterestCollection"));
builder.Services.AddSingleton(db.GetCollection<PathToNode>("pathToNodeCollection"));

builder.Services.AddScoped<IPointOfInterestRepository, PointOfInterestRepository>();
builder.Services.AddScoped<IPathRepository, PathRepository>();
builder.Services.AddCustomJwtAuthentication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
