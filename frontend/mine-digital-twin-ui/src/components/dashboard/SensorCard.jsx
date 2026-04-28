export default function SensorCard({ title, value, unit, status }) {
  return (
    <div className={`card ${status?.toLowerCase() || ""}`}>
      <span className="card-title">{title}</span>
      <strong>{value}{unit ? ` ${unit}` : ""}</strong>
      {status && <small>Status: {status}</small>}
    </div>
  );
}
