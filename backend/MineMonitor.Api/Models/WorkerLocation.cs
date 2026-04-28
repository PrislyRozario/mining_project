namespace MineMonitor.Api.Models;

public class WorkerLocation
{
    public string WorkerId { get; set; } = "";
    public string Name { get; set; } = "";
    public Position Position { get; set; } = new();
    public string Zone { get; set; } = "Main Tunnel";
}
