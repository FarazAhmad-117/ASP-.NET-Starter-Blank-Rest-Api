var builder = WebApplication.CreateBuilder(args);

// Area to configure all the services



var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/api", () => "Hello Api!");


// For some json data

app.MapGet("/data", () => new
{
    success = true,
    message = "Hello Boi",
    Time = DateTime.Now
});


app.Run();
