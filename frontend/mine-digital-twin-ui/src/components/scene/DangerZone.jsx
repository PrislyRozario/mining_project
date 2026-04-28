export default function DangerZone({ machine, isActive = true }) {
  if (!machine) return null;

  const { x, y, z } = machine.position;

  return (
    <mesh position={[x, y + 0.02, z]} rotation={[-Math.PI / 2, 0, 0]}>
      <ringGeometry args={[1.4, 1.7, 64]} />
      <meshBasicMaterial
        color={isActive ? "#ef4444" : "#f59e0b"}
        transparent
        opacity={0.35}
        side={2}
      />
    </mesh>
  );
}
