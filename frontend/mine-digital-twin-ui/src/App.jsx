import React from "react";
import MineScene from "./components/scene/MineScene";
import EquipmentPanel from "./components/dashboard/EquipmentPanel";
import WorkerPanel from "./components/dashboard/WorkerPanel";
import EnvironmentalPanel from "./components/dashboard/EnvironmentalPanel";
import AlertPanel from "./components/dashboard/AlertPanel";
import { useMineTelemetry } from "./hooks/useMineTelemetry";

export default function App() {
  const { telemetry, connected } = useMineTelemetry();

  return (
    <div className="app-shell">
      <main className="scene-area">
        <MineScene telemetry={telemetry} />
      </main>

      <aside className="dashboard">
        <div className="header">
          <div>
            <h1>Mine Safety Digital Twin</h1>
            <p>Real-time 3D underground monitoring demo</p>
          </div>

          <span className={connected ? "badge online" : "badge offline"}>
            {connected ? "Live" : "Offline"}
          </span>
        </div>

        <EnvironmentalPanel sensors={telemetry.sensors} />
        <EquipmentPanel equipment={telemetry.equipment} />
        <WorkerPanel workers={telemetry.workers} />
        <AlertPanel alerts={telemetry.alerts} />

        <footer>
          Last update: {new Date(telemetry.timestamp).toLocaleTimeString()}
        </footer>
      </aside>
    </div>
  );
}
