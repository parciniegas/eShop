namespace eShop.Catalog.API.Config;

internal static partial class Config
{
    public static void ConfigureSecurityPolicies(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication().AddJwtBearer();
        builder.Services.AddAuthorization();

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("catalog.guest", policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim("catalog.guest", "true")))
            .AddPolicy("catalog.admin", policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim("catalog.admin", "true") ||
                    c.User.IsInRole("admin")))
            .AddPolicy("catalog.read", policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim("catalog.read", "true") ||
                    c.User.IsInRole("admin")))
            .AddPolicy("catalog.write", policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim("catalog.write", "true") ||
                    c.User.IsInRole("admin")))
            .AddPolicy("catalog.delete", policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim("catalog.delete", "true") ||
                    c.User.IsInRole("admin")))
            .AddPolicy("catalog.update", policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim("catalog.update", "true") ||
                    c.User.IsInRole("admin")))
            .AddPolicy("catalog.create", policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim("catalog.create", "true") ||
                    c.User.IsInRole("admin")));
    }
}