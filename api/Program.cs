using Microsoft.EntityFrameworkCore;
using api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DBcontext>(options =>
            options.UseNpgsql("host=localhost;port=5432;database=Tegula;user id=postgres;password=postgres"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myFirstPolicy",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("myFirstPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
