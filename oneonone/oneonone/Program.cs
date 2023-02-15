using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OneContext>(options =>
options.UseInMemoryDatabase("OneList"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("sample", () => "One on One");

app.MapGet("One", async (OneContext oc)=>
await oc.Ones.ToListAsync());

app.MapGet("One/{id}", async (int id, OneContext oc) =>
await oc.Ones.FindAsync(id));

app.MapPost("One", async ([FromBody]One o, OneContext oc) =>
{
    oc.Ones.Add(o);
    await oc.SaveChangesAsync();
});

app.MapPut("One/{id}", async (int id, [FromBody] One o, OneContext oc) =>
{
    var ids = await oc.Ones.FindAsync(id);
    if (ids is null) return Results.NotFound();
    ids.Name = o.Name;
    ids.Batch = o.Batch;
    await oc.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("One/{id}", async (int id, OneContext oc) =>
{
    if (await oc.Ones.FindAsync(id) is One p)
    {
        oc.Ones.Remove(p);
        await oc.SaveChangesAsync();
        return Results.Ok(p);
    }
    return Results.NotFound();
});

app.Run();

class One
{
    public int Id{get;set;}

    public string Name { get;set;}

    public string Batch { get; set; }
}
class OneContext : DbContext
{ 
    public OneContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<One> Ones { get; set; }
}




