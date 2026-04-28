import * as signalR from "@microsoft/signalr";

export function createMineConnection(onTelemetry, onConnectionChange) {
  const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000/mineHub")
    .withAutomaticReconnect()
    .build();

  connection.on("ReceiveMineTelemetry", (data) => {
    onTelemetry(data);
  });

  connection.onreconnecting(() => onConnectionChange(false));
  connection.onreconnected(() => onConnectionChange(true));
  connection.onclose(() => onConnectionChange(false));

  connection
    .start()
    .then(() => onConnectionChange(true))
    .catch((error) => {
      console.error("SignalR connection failed:", error);
      onConnectionChange(false);
    });

  return connection;
}
