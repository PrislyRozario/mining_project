using MineMonitor.Api.Models;

namespace MineMonitor.Api.Services;

public class ProximityDetectionService
{
    public double DangerDistance { get; set; } = 1.7;

    public List<AlertEvent> Detect(List<WorkerLocation> workers, List<EquipmentStatus> equipment)
    {
        var alerts = new List<AlertEvent>();

        foreach (var worker in workers)
        {
            foreach (var machine in equipment)
            {
                var distance = Distance(worker.Position, machine.Position);

                if (distance <= DangerDistance)
                {
                    alerts.Add(new AlertEvent
                    {
                        Level = "Critical",
                        Source = "Proximity Detection",
                        Message = $"{worker.Name} is too close to {machine.Name}. Distance: {distance:F2} m",
                        Timestamp = DateTime.UtcNow
                    });
                }
            }
        }

        return alerts;
    }

    private static double Distance(Position a, Position b)
    {
        var dx = a.X - b.X;
        var dy = a.Y - b.Y;
        var dz = a.Z - b.Z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}
