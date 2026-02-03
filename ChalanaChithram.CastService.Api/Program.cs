using ChalanaChithram.CastService.Api.Data;
using ChalanaChithram.CastService.Api.Repositories;
using ChalanaChithram.CastService.Api.Repositories.Interfaces;
using ChalanaChithram.CastService.Api.Seed;
using ChalanaChithram.CastService.Api.Services;
using ChalanaChithram.CastService.Api.Services.Interfaces;
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

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICastRepository, CastRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment() && args.Length == 0)
{
    await DatabaseSeeder.SeedAsync(app.Services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
