var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.MapControllers();
app.MapRazorPages();

app.Run();
