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
            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSingleton<AlertService>();
builder.Services.AddSingleton<ProximityDetectionService>();
builder.Services.AddHostedService<MineSimulationService>();

var app = builder.Build();

app.UseRouting();

app.UseCors("AllowFrontend");

app.MapControllers().RequireCors("AllowFrontend");

app.MapHub<MineHub>("/mineHub").RequireCors("AllowFrontend");

app.MapGet("/", () => "Mine Monitor API is running. CORS VERSION 2")
   .RequireCors("AllowFrontend");

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");