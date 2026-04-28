import { Text } from "@react-three/drei";
import { statusColor } from "../../utils/statusColor";

export default function GasSensor({ sensor }) {
  const { x, y, z } = sensor.position;
  const color = statusColor(sensor.status);

  return (
    <group position={[x, y, z]}>
      <mesh>
        <sphereGeometry args={[0.25, 32, 32]} />
        <meshStandardMaterial color={color} emissive={color} emissiveIntensity={0.35} />
      </mesh>

      <mesh position={[0, -0.45, 0]}>
        <cylinderGeometry args={[0.07, 0.07, 0.8, 16]} />
        <meshStandardMaterial color="#94a3b8" />
      </mesh>

      <Text position={[0, 0.65, 0]} fontSize={0.2} color="white" anchorX="center">
        {sensor.name}
      </Text>
    </group>
  );
}
