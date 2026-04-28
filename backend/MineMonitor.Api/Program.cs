using MineMonitor.Api.Hubs;
using MineMonitor.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddSingleton<AlertService>();
builder.Services.AddSingleton<ProximityDetectionService>();
builder.Services.AddHostedService<MineSimulationService>();

var app = builder.Build();

// Manual CORS fix for Render + SignalR
app.Use(async (context, next) =>
{
    var origin = context.Request.Headers["Origin"].ToString();

    if (!string.IsNullOrEmpty(origin))
    {
        context.Response.Headers["Access-Control-Allow-Origin"] = origin;
        context.Response.Headers["Access-Control-Allow-Credentials"] = "true";
        context.Response.Headers["Access-Control-Allow-Headers"] =
            context.Request.Headers["Access-Control-Request-Headers"].ToString();
        context.Response.Headers["Access-Control-Allow-Methods"] =
            "GET, POST, PUT, DELETE, OPTIONS";
    }

    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 204;
        return;
    }

    await next();
});

app.MapControllers();
app.MapHub<MineHub>("/mineHub");

app.MapGet("/", () => "Mine Monitor API is running. Manual CORS enabled.");

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");