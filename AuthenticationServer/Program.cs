var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("all", policy => policy.AllowAnyOrigin()));
builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseCors("all");
app.MapControllers();
app.MapRazorPages();
app.MapGet("/", async context => context.Response.Redirect("/Generate"));

app.Run();
