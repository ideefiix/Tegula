using Microsoft.EntityFrameworkCore;
using api.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = $"host={builder.Configuration.GetValue<string>("DatabaseSettings:Host")};"
                    + $"port={builder.Configuration.GetValue<string>("DatabaseSettings:Port")};"
                    + $"database={builder.Configuration.GetValue<string>("DatabaseSettings:Database")};"
                    + $"user id={builder.Configuration.GetValue<string>("DatabaseSettings:User")};"
                    + $"password={builder.Configuration.GetValue<string>("DatabaseSettings:Password")};";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DBcontext>(options =>
            options.UseNpgsql(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myFirstPolicy",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();

                      });
});
// USE HTTP
/* if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.RedirectStatusCode = (int)System.Net.HttpStatusCode.PermanentRedirect;
        options.HttpsPort = 443; 
    });
} */

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// USE HTTP atm. I get SSL connection refused with HTTTPS. Probobly because I have no certification?
/* app.UseHttpsRedirection(); */

app.UseCors("myFirstPolicy");
app.UseAuthorization();

app.MapControllers();

// Apply migrations
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<DBcontext>())
    context.Database.Migrate();

app.Run();

