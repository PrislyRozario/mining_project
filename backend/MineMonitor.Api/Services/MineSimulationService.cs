using Microsoft.AspNetCore.SignalR;
using MineMonitor.Api.Hubs;
using MineMonitor.Api.Models;

namespace MineMonitor.Api.Services;

public class MineSimulationService : BackgroundService
{
    private readonly IHubContext<MineHub> _hubContext;
    private readonly ProximityDetectionService _proximityService;
    private readonly AlertService _alertService;
    private readonly Random _random = new();
    private double _tick = 0;

    public MineSimulationService(
        IHubContext<MineHub> hubContext,
        ProximityDetectionService proximityService,
        AlertService alertService)
    {
        _hubContext = hubContext;
        _proximityService = proximityService;
        _alertService = alertService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _tick += 0.25;

            var workers = GenerateWorkers();
            var equipment = GenerateEquipment();
            var sensors = GenerateSensors();

            var alerts = new List<AlertEvent>();
            alerts.AddRange(_proximityService.Detect(workers, equipment));
            alerts.AddRange(DetectEquipmentAlerts(equipment));
            alerts.AddRange(DetectEnvironmentalAlerts(sensors));

            _alertService.AddRange(alerts);

            var telemetry = new MineTelemetry
            {
                Workers = workers,
                Equipment = equipment,
                Sensors = sensors,
                Alerts = _alertService.GetRecent(),
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.All.SendAsync("ReceiveMineTelemetry", telemetry, stoppingToken);

            Console.WriteLine($"Telemetry sent: workers={workers.Count}, equipment={equipment.Count}, sensors={sensors.Count}, alerts={telemetry.Alerts.Count}");

            await Task.Delay(1500, stoppingToken);
        }
    }

    private List<WorkerLocation> GenerateWorkers()
    {
        return new List<WorkerLocation>
        {
            new()
            {
                WorkerId = "worker-01",
                Name = "Worker A",
                Zone = "Main Tunnel",
                Position = new Position
                {
                    X = Math.Sin(_tick) * 3.8,
                    Y = 0.25,
                    Z = -1.2
                }
            },
            new()
            {
                WorkerId = "worker-02",
                Name = "Worker B",
                Zone = "Ventilation Crosscut",
                Position = new Position
                {
                    X = -2.2,
                    Y = 0.25,
                    Z = Math.Cos(_tick * 0.7) * 2.2
                }
            }
        };
    }

    private List<EquipmentStatus> GenerateEquipment()
    {
        var loaderTemp = 65 + Math.Abs(Math.Sin(_tick * 0.6)) * 30;
        var loaderVibration = Math.Round(0.3 + Math.Abs(Math.Cos(_tick)) * 1.0, 2);

        var conveyorTemp = 55 + Math.Abs(Math.Cos(_tick * 0.5)) * 20;
        var conveyorVibration = Math.Round(0.2 + Math.Abs(Math.Sin(_tick * 0.8)) * 0.7, 2);

        return new List<EquipmentStatus>
        {
            new()
            {
                EquipmentId = "loader-01",
                Name = "Mining Loader",
                Position = new Position
                {
                    X = Math.Cos(_tick * 0.45) * 3.0,
                    Y = 0.35,
                    Z = 1.3
                },
                Speed = Math.Round(1.0 + Math.Abs(Math.Sin(_tick)) * 3.0, 2),
                Temperature = Math.Round(loaderTemp, 1),
                Vibration = loaderVibration,
                Status = GetEquipmentStatus(loaderTemp, loaderVibration)
            },
            new()
            {
                EquipmentId = "conveyor-01",
                Name = "Ore Conveyor",
                Position = new Position { X = 0, Y = 0.35, Z = -2.8 },
                Speed = Math.Round(2.0 + Math.Abs(Math.Sin(_tick * 0.4)) * 4.0, 2),
                Temperature = Math.Round(conveyorTemp, 1),
                Vibration = conveyorVibration,
                Status = GetEquipmentStatus(conveyorTemp, conveyorVibration)
            }
        };
    }

    private List<EnvironmentalSensor> GenerateSensors()
    {
        var methane = Math.Round(0.4 + Math.Abs(Math.Sin(_tick * 0.35)) * 1.6, 2);
        var co = Math.Round(8 + Math.Abs(Math.Cos(_tick * 0.55)) * 38, 1);
        var oxygen = Math.Round(20.9 - Math.Abs(Math.Sin(_tick * 0.5)) * 2.2, 1);
        var temp = Math.Round(22 + Math.Abs(Math.Cos(_tick * 0.4)) * 10, 1);

        return new List<EnvironmentalSensor>
        {
            new()
            {
                SensorId = "gas-01",
                Name = "Gas Sensor A",
                Position = new Position { X = -3.8, Y = 0.8, Z = 0 },
                Methane = methane,
                CarbonMonoxide = co,
                Oxygen = oxygen,
                Temperature = temp,
                Status = GetEnvironmentStatus(methane, co, oxygen)
            },
            new()
            {
                SensorId = "gas-02",
                Name = "Gas Sensor B",
                Position = new Position { X = 3.8, Y = 0.8, Z = -2.2 },
                Methane = Math.Round(methane * 0.7, 2),
                CarbonMonoxide = Math.Round(co * 0.55, 1),
                Oxygen = Math.Round(oxygen + 0.5, 1),
                Temperature = Math.Round(temp - 1, 1),
                Status = GetEnvironmentStatus(methane * 0.7, co * 0.55, oxygen + 0.5)
            }
        };
    }

    private static string GetEquipmentStatus(double temperature, double vibration)
    {
        if (temperature > 86 || vibration > 1.1) return "Fault";
        if (temperature > 74 || vibration > 0.85) return "Warning";
        return "Normal";
    }

    private static string GetEnvironmentStatus(double methane, double co, double oxygen)
    {
        if (methane > 1.4 || co > 35 || oxygen < 19.2) return "Danger";
        if (methane > 1.0 || co > 25 || oxygen < 19.8) return "Warning";
        return "Normal";
    }

    private static List<AlertEvent> DetectEquipmentAlerts(List<EquipmentStatus> equipment)
    {
        return equipment
            .Where(e => e.Status is "Fault" or "Warning")
            .Select(e => new AlertEvent
            {
                Level = e.Status == "Fault" ? "Critical" : "Warning",
                Source = e.Name,
                Message = $"{e.Name} status is {e.Status}. Temp={e.Temperature}°C, vibration={e.Vibration}",
                Timestamp = DateTime.UtcNow
            })
            .ToList();
    }

    private static List<AlertEvent> DetectEnvironmentalAlerts(List<EnvironmentalSensor> sensors)
    {
        return sensors
            .Where(s => s.Status is "Danger" or "Warning")
            .Select(s => new AlertEvent
            {
                Level = s.Status == "Danger" ? "Critical" : "Warning",
                Source = s.Name,
                Message = $"{s.Name} atmosphere status is {s.Status}. CH4={s.Methane}%, CO={s.CarbonMonoxide}ppm, O2={s.Oxygen}%",
                Timestamp = DateTime.UtcNow
            })
            .ToList();
    }
}
