// ADD DEPENDENCY INJECTION
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();


// CONFIGURE HTTP REQUEST
var app = builder.Build();
app.MapCarter();

app.Run();
