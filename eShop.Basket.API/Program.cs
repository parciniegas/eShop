using eShop.Basket.Domain.Cart;
using eShop.Basket.Infrastructure.Redis;
using Ilse.CorrelationId.DependencyInjection;
using Ilse.CorrelationId.Middleware;
using Ilse.Cqrs.Commands;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCorrelationId();
builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddEndpoints();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCorrelationId();
app.MapEndpoints();

app.UseHttpsRedirection();

app.Run();