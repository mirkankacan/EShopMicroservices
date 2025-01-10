using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        // In 10 seconds max 5 request
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
        // Returns 503 Service Unavailable
    });
});

var app = builder.Build();

// Use rate limiter before reverse proxy!
app.UseRateLimiter();

app.MapReverseProxy();

app.Run();