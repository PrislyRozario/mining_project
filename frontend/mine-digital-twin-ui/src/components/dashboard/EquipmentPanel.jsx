import SensorCard from "./SensorCard";

export default function EquipmentPanel({ equipment }) {
  return (
    <section className="panel">
      <h2>Equipment</h2>
      <div className="mini-grid">
        {equipment.map((item) => (
          <div className="equipment-box" key={item.equipmentId}>
            <h3>{item.name}</h3>
            <SensorCard title="Temperature" value={item.temperature} unit="°C" status={item.status} />
            <SensorCard title="Speed" value={item.speed} unit="m/s" />
            <SensorCard title="Vibration" value={item.vibration} />
          </div>
        ))}
      </div>
    </section>
  );
}
