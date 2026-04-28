import { Text } from "@react-three/drei";

export default function WorkerTag({ worker }) {
  const { x, y, z } = worker.position;

  return (
    <group position={[x, y, z]}>
      <mesh position={[0, 0.45, 0]}>
        <capsuleGeometry args={[0.18, 0.55, 8, 16]} />
        <meshStandardMaterial color="#38bdf8" />
      </mesh>

      <mesh position={[0, 0.95, 0]}>
        <sphereGeometry args={[0.18, 16, 16]} />
        <meshStandardMaterial color="#f8fafc" />
      </mesh>

      <Text
        position={[0, 1.35, 0]}
        fontSize={0.22}
        color="white"
        anchorX="center"
      >
        {worker.name}
      </Text>
    </group>
  );
}
