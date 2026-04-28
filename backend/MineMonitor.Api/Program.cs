using MineMonitor.Api.Hubs;
using MineMonitor.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                         "http://localhost:5173",
                         "https://mining-project-92l7.vercel.app",
                         "https://mining-project-92l7-qdzkwjfqd-prisly-rozarios-projects.vercel.app"
)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSingleton<AlertService>();
builder.Services.AddSingleton<ProximityDetectionService>();
builder.Services.AddHostedService<MineSimulationService>();

var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapControllers();
app.MapHub<MineHub>("/mineHub");

app.MapGet("/", () => "Mine Monitor API is running.");

// app.Run();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");
