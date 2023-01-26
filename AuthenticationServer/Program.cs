var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("all", policy => policy.AllowAnyOrigin()));
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("all");
app.MapGet("/", () => "Authentication server");
app.MapControllers();

app.Run();
