using DF=DataFluentAPI.Entities;
using df = DataFluentAPI.View;
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
builder.Services.AddDbContext<df.ProjectContext>(options => options.UseSqlServer(obj));
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

builder.Services.AddScoped<IAgeFilter, AgeFilterRepo>();
builder.Services.AddScoped<IAgeLogic, AgeFilterLogic>();


//var cors = "cors";
//builder.Services.AddCors(options =>
//    options.AddPolicy(cors, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));

builder.Services.AddCors(p => p.AddPolicy("cors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

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

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
