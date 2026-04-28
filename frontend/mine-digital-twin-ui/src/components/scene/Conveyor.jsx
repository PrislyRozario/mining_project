import { Text } from "@react-three/drei";
import { statusColor } from "../../utils/statusColor";

export default function Conveyor({ machine }) {
  const color = statusColor(machine.status);

  return (
    <group position={[0, 0, -2.8]}>
      <mesh position={[0, 0.35, 0]}>
        <boxGeometry args={[6.5, 0.35, 0.85]} />
        <meshStandardMaterial color="#475569" />
      </mesh>

      <mesh position={[0, 0.65, 0]}>
        <boxGeometry args={[6.2, 0.12, 0.65]} />
        <meshStandardMaterial color={color} />
      </mesh>

      <mesh position={[-2.5, 0.9, 0]}>
        <boxGeometry args={[0.5, 0.35, 0.45]} />
        <meshStandardMaterial color="#e5e7eb" />
      </mesh>

      <Text position={[0, 1.25, 0]} fontSize={0.22} color="white" anchorX="center">
        {machine?.name ?? "Ore Conveyor"}
      </Text>
    </group>
  );
}
