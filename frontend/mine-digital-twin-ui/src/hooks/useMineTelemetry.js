import { useEffect, useState } from "react";
import { createMineConnection } from "../services/signalrService";

const initialTelemetry = {
  workers: [],
  equipment: [],
  sensors: [],
  alerts: [],
  timestamp: new Date().toISOString(),
};

export function useMineTelemetry() {
  const [telemetry, setTelemetry] = useState(initialTelemetry);
  const [connected, setConnected] = useState(false);

  useEffect(() => {
    const connection = createMineConnection(setTelemetry, setConnected);

    return () => {
      connection.stop();
    };
  }, []);

  return { telemetry, connected };
}
