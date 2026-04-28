namespace MineMonitor.Api.Models;

public class EnvironmentalSensor
{
    public string SensorId { get; set; } = "";
    public string Name { get; set; } = "";
    public Position Position { get; set; } = new();
    public double Methane { get; set; }
    public double CarbonMonoxide { get; set; }
    public double Oxygen { get; set; }
    public double Temperature { get; set; }
    public string Status { get; set; } = "Normal";
}
