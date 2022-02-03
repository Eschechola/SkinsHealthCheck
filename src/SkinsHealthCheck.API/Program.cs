using Microsoft.EntityFrameworkCore;
using SkinsApiHealthChecks.Api.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionStrings:SqlServer"];
builder.Services.AddDbContext<SkinContext>(options =>
    options
        .UseSqlServer(connectionString)
        .EnableSensitiveDataLogging());

builder.Services
    .AddHealthChecks()
    .AddDbContextCheck<SkinContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
    endpoints.MapControllers();
});

app.Run();
