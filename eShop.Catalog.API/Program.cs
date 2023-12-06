using IBus = eShop.Catalog.Application.Bus.IBus;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((_, cfg) =>
    {
        cfg.Host("localhost", "/", c =>
        {
            c.Username("guest");
            c.Password("guest");
        });
    });
});

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
builder.Services.AddEvents();
builder.Services.AddEndpoints();
builder.Services.AddTenantContext();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBus, eShop.Catalog.Infrastructure.Bus.Bus>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

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