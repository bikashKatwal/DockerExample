using Docker.Les.Admin.API;
using Docker.Les.Admin.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var server = builder.Configuration["DBServer"] ?? "localhost";
var port = builder.Configuration["DBPort"] ?? "1443";
var user = builder.Configuration["DBUser"] ?? "SA";
var password = builder.Configuration["DBPassword"] ?? "Pa$$w0rd2022";
var database = builder.Configuration["Database"] ?? "Colours";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password} ");
});

var app = builder.Build();

PrepDB.PrepPopulation(app);

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
