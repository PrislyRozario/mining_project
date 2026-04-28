namespace MineMonitor.Api.Models;

public class AlertEvent
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Level { get; set; } = "Info";
    public string Message { get; set; } = "";
    public string Source { get; set; } = "";
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
