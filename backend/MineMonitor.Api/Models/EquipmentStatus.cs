namespace MineMonitor.Api.Models;

public class EquipmentStatus
{
    public string EquipmentId { get; set; } = "";
    public string Name { get; set; } = "";
    public Position Position { get; set; } = new();
    public double Speed { get; set; }
    public double Temperature { get; set; }
    public double Vibration { get; set; }
    public string Status { get; set; } = "Normal";
}
