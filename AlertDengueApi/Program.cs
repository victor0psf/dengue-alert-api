using AlertDengueApi.Data;
using AlertDengueApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using AlertDengueApi.Repositories;
using AlertDengueApi.Services;
using AlertDengueApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IDengueAlertRepository, DengueAlertRepository>();
builder.Services.AddScoped<IDengueAlertService, DengueAlertService>();
builder.Services.AddScoped<IEpidemologicalWeekHelper, EpidemologicalWeekHelper>();
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dengue Alert API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
