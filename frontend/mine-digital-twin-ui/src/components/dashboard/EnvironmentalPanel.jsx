import SensorCard from "./SensorCard";

export default function EnvironmentalPanel({ sensors }) {
  const primary = sensors[0];

  if (!primary) {
    return null;
  }

  return (
    <section className="panel">
      <h2>Atmospheric Monitoring</h2>
      <div className="sensor-grid">
        <SensorCard title="Methane" value={primary.methane} unit="%" status={primary.status} />
        <SensorCard title="CO" value={primary.carbonMonoxide} unit="ppm" />
        <SensorCard title="Oxygen" value={primary.oxygen} unit="%" />
        <SensorCard title="Temp" value={primary.temperature} unit="°C" />
      </div>
    </section>
  );
}
