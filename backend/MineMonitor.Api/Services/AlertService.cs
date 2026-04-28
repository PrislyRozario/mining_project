using MineMonitor.Api.Models;

namespace MineMonitor.Api.Services;

public class AlertService
{
    private readonly Queue<AlertEvent> _alerts = new();

    public void AddRange(IEnumerable<AlertEvent> alerts)
    {
        foreach (var alert in alerts)
        {
            _alerts.Enqueue(alert);
        }

        while (_alerts.Count > 8)
        {
            _alerts.Dequeue();
        }
    }

    public List<AlertEvent> GetRecent()
    {
        return _alerts.Reverse().ToList();
    }
}
