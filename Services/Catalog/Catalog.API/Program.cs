// ADD DEPENDENCY INJECTION
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

// CONFIGURE HTTP REQUEST
var app = builder.Build();
app.MapCarter();

app.Run();
