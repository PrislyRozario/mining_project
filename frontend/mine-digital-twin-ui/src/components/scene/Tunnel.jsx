export default function Tunnel() {
  return (
    <>
      <mesh position={[0, -0.05, 0]}>
        <boxGeometry args={[10, 0.1, 7]} />
        <meshStandardMaterial color="#1f2937" />
      </mesh>

      <mesh position={[0, 1.8, -3.5]}>
        <boxGeometry args={[10, 3.6, 0.15]} />
        <meshStandardMaterial color="#374151" />
      </mesh>

      <mesh position={[0, 1.8, 3.5]}>
        <boxGeometry args={[10, 3.6, 0.15]} />
        <meshStandardMaterial color="#374151" />
      </mesh>

      <mesh position={[-5, 1.8, 0]}>
        <boxGeometry args={[0.15, 3.6, 7]} />
        <meshStandardMaterial color="#4b5563" />
      </mesh>

      <mesh position={[5, 1.8, 0]}>
        <boxGeometry args={[0.15, 3.6, 7]} />
        <meshStandardMaterial color="#4b5563" />
      </mesh>

      <mesh position={[0, 3.6, 0]}>
        <boxGeometry args={[10, 0.15, 7]} />
        <meshStandardMaterial color="#111827" />
      </mesh>

      <gridHelper args={[10, 10]} position={[0, 0.01, 0]} />
    </>
  );
}
