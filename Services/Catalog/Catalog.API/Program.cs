// ADD DEPENDENCY INJECTION
using BuildingBlocks.Exceptions.Handler;

var assembly = typeof(Program).Assembly;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


// CONFIGURE HTTP REQUEST
var app = builder.Build();
app.MapCarter();
app.UseExceptionHandler(options => { });

app.Run();
