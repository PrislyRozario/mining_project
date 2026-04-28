export function statusColor(status) {
  switch (status) {
    case "Normal":
      return "#22c55e";
    case "Warning":
      return "#f59e0b";
    case "Fault":
    case "Danger":
      return "#ef4444";
    default:
      return "#38bdf8";
  }
}
