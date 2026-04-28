import { Text } from "@react-three/drei";
import { statusColor } from "../../utils/statusColor";

export default function MiningVehicle({ machine }) {
  const { x, y, z } = machine.position;
  const color = statusColor(machine.status);

  return (
    <group position={[x, y, z]}>
      <mesh position={[0, 0.35, 0]}>
        <boxGeometry args={[1.2, 0.65, 0.8]} />
        <meshStandardMaterial color={color} />
      </mesh>

      <mesh position={[0.55, 0.8, 0]}>
        <boxGeometry args={[0.45, 0.45, 0.65]} />
        <meshStandardMaterial color="#64748b" />
      </mesh>

      <mesh position={[-0.4, 0, -0.45]}>
        <cylinderGeometry args={[0.18, 0.18, 0.18, 20]} rotation={[Math.PI / 2, 0, 0]} />
        <meshStandardMaterial color="#020617" />
      </mesh>

      <mesh position={[0.4, 0, -0.45]}>
        <cylinderGeometry args={[0.18, 0.18, 0.18, 20]} rotation={[Math.PI / 2, 0, 0]} />
        <meshStandardMaterial color="#020617" />
      </mesh>

      <mesh position={[-0.4, 0, 0.45]}>
        <cylinderGeometry args={[0.18, 0.18, 0.18, 20]} rotation={[Math.PI / 2, 0, 0]} />
        <meshStandardMaterial color="#020617" />
      </mesh>

      <mesh position={[0.4, 0, 0.45]}>
        <cylinderGeometry args={[0.18, 0.18, 0.18, 20]} rotation={[Math.PI / 2, 0, 0]} />
        <meshStandardMaterial color="#020617" />
      </mesh>

      <Text position={[0, 1.45, 0]} fontSize={0.22} color="white" anchorX="center">
        {machine.name}
      </Text>
    </group>
  );
}
