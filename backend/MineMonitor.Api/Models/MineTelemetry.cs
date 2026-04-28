namespace MineMonitor.Api.Models;

public class MineTelemetry
{
    public List<WorkerLocation> Workers { get; set; } = new();
    public List<EquipmentStatus> Equipment { get; set; } = new();
    public List<EnvironmentalSensor> Sensors { get; set; } = new();
    public List<AlertEvent> Alerts { get; set; } = new();
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
