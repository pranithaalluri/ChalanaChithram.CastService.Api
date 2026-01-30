using ChalanaChithram.CastService.Api.Data;
using ChalanaChithram.CastService.Api.Seed;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string? connectionString = builder.Configuration.GetConnectionString("CastServiceDb");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("CastServiceDb connection string missing.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

await DatabaseSeeder.SeedAsync(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
