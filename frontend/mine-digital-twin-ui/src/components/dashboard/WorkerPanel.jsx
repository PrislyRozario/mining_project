export default function WorkerPanel({ workers }) {
  return (
    <section className="panel">
      <h2>Personnel Tracking</h2>
      {workers.map((worker) => (
        <div className="row" key={worker.workerId}>
          <div>
            <strong>{worker.name}</strong>
            <small>{worker.zone}</small>
          </div>
          <span>
            X:{worker.position.x.toFixed(1)} Z:{worker.position.z.toFixed(1)}
          </span>
        </div>
      ))}
    </section>
  );
}
