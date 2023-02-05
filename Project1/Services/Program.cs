using DF=DataFluentAPI.Entities;
using DataFluentAPI;
using Microsoft.EntityFrameworkCore;
using BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var obj = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<DF.ProjectContext>(options => options.UseSqlServer(obj));


builder.Services.AddScoped<IRepo<DF.UserDetails>, SQLRepo>();
builder.Services.AddScoped<ILogic, Logic>();


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
