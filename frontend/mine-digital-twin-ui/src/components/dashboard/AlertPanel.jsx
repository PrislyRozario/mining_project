export default function AlertPanel({ alerts }) {
  return (
    <section className="panel">
      <h2>Live Alerts</h2>

      {alerts.length === 0 && <p className="empty">No active alerts.</p>}

      {alerts.map((alert) => (
        <div className={`alert ${alert.level.toLowerCase()}`} key={alert.id}>
          <strong>{alert.level}</strong>
          <p>{alert.message}</p>
          <small>{alert.source} • {new Date(alert.timestamp).toLocaleTimeString()}</small>
        </div>
      ))}
    </section>
  );
}
