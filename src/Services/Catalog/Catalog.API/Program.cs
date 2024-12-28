var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter(null, config =>
{
    var moduleTypes = typeof(Program).Assembly.GetTypes()
      .Where(t => typeof(ICarterModule).IsAssignableFrom(t) && !t.IsAbstract);
    config.WithModules(moduleTypes.ToArray());
});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("PostgreSQLConnection")!);
}).UseLightweightSessions();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();