import { Canvas } from "@react-three/fiber";
import { OrbitControls, Text } from "@react-three/drei";
import Tunnel from "./Tunnel";
import WorkerTag from "./WorkerTag";
import MiningVehicle from "./MiningVehicle";
import Conveyor from "./Conveyor";
import GasSensor from "./GasSensor";
import DangerZone from "./DangerZone";

export default function MineScene({ telemetry }) {
  const loader = telemetry.equipment.find((e) => e.equipmentId === "loader-01");
  const conveyor = telemetry.equipment.find((e) => e.equipmentId === "conveyor-01");

  return (
    <Canvas camera={{ position: [7, 6, 8], fov: 48 }}>
      <ambientLight intensity={0.65} />
      <directionalLight position={[5, 8, 5]} intensity={1.2} />

      <OrbitControls />

      <Tunnel />

      {loader && <DangerZone machine={loader} isActive={loader.status !== "Normal"} />}
      {loader && <MiningVehicle machine={loader} />}
      {conveyor && <Conveyor machine={conveyor} />}

      {telemetry.workers.map((worker) => (
        <WorkerTag key={worker.workerId} worker={worker} />
      ))}

      {telemetry.sensors.map((sensor) => (
        <GasSensor key={sensor.sensorId} sensor={sensor} />
      ))}

      <Text position={[0, 3.25, 0]} fontSize={0.32} color="white" anchorX="center">
        Underground Mine Digital Twin
      </Text>
    </Canvas>
  );
}
