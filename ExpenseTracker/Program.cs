using ExpenseTracker;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
 
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection; 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//mysql connection build
var connString = builder.Configuration.GetConnectionString("GeorgekosmidisConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28)); // Adjust the version based on your MySQL server version
builder.Services.AddDbContext<ExpenseTrackerDbContext>(options => options.UseMySql(connString, serverVersion));

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