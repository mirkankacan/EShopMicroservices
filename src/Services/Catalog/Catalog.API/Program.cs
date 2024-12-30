var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

// Add services to the container.
builder.Services.AddCarter(null, config =>
{
    var moduleTypes = assembly.GetTypes()
      .Where(t => typeof(ICarterModule).IsAssignableFrom(t) && !t.IsAbstract);
    config.WithModules(moduleTypes.ToArray());
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("PostgreSQLConnection")!);
}).UseLightweightSessions();

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.UseExceptionHandler(opt => { });

app.Run();