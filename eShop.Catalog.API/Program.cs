using eShop.Catalog.API.Config;
using eShop.Catalog.API.Middleware;
using eShop.Catalog.Infrastructure.Repository;
using FluentValidation;
using Ilse.CorrelationId.DependencyInjection;
using Ilse.CorrelationId.Middleware;
using Ilse.Cqrs.Commands;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi;
using Ilse.Repository.Abstracts;
using Ilse.Repository.Contracts;
using Ilse.Repository.Implementations;
using Ilse.TenantContext.Context;
using Ilse.TenantContext.DependencyInjection;
using Ilse.TenantContext.Middleware;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
Config.ConfigureSwagger(builder);
Config.ConfigureSecurityPolicies(builder);

// NLog: Setup the logger first to catch all errors
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddDbContext<BaseContext, CatalogContext>((services, options) =>
{
    var tenantId = services.GetService<ITenantContextAccessor>()?.TenantContext?.TenantId ?? "Default";
    var connectionString = services.GetService<IConfiguration>()?.GetConnectionString(tenantId);
    options.UseNpgsql(connectionString);
});

builder.Services.AddCorrelationId();
builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddEndpoints();
builder.Services.AddTenantContext();
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCorrelationId();
app.UseTenantContext();
app.MapEndpoints();
app.UseMiddleware<LoggingMiddleware>();

app.UseExceptionHandler("/error");

app.Run();