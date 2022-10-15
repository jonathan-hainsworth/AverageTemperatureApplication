using AverageTemperatureApplication.DAL.Impementations;
using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Implementations;
using AverageTemperatureApplication.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAverageTemperateCache, AverageTemperateCache>();
builder.Services.AddTransient<IAverageTemperatureSourceA, AverageTemperatureSourceA>();
builder.Services.AddTransient<IAverageTemperatureSourceB, AverageTemperatureSourceB>();

builder.Services.AddScoped<IAverageTemperatureService, AverageTemperatureService>();

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
