var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.MapRazorPages();

app.Run();