using DF=DataFluentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using BusinessLogic;
using DataFluentAPI.Entities;
using DataFluentAPI;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var obj = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<DF.ProjectContext>(options => options.UseSqlServer(obj));
builder.Services.AddScoped<Validate>();

builder.Services.AddScoped<IRepo<DF.UserDetails>, DF.SQLRepo>();
builder.Services.AddScoped<ILogic, Logic>();

builder.Services.AddScoped<ISkillRepo, DF.SkillRepo>();
builder.Services.AddScoped<ISkillLogic, SkillLogic>();

builder.Services.AddScoped<IEducationRepo, EducationRepo>();
builder.Services.AddScoped<IEducationLogic, EducationLogic>();

builder.Services.AddScoped<IContactRepo, ContactRepo>();
builder.Services.AddScoped<IContactLogic, ContactLogic>();

builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
builder.Services.AddScoped<ICompanyLogic, CompanyLogic>();


JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};


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
