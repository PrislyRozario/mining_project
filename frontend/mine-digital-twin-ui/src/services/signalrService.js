import * as signalR from "@microsoft/signalr";

export function createMineConnection(onTelemetry, onConnectionChange) {
  const hubUrl = "https://mining-project-4k5s.onrender.com/mineHub";

  console.log("Connecting to SignalR:", hubUrl);

  const connection = new signalR.HubConnectionBuilder()
    .withUrl(hubUrl, {
      transport: signalR.HttpTransportType.WebSockets,
      skipNegotiation: true,
    })
    .withAutomaticReconnect()
    .build();

  connection.on("ReceiveMineTelemetry", (data) => {
    console.log("Mine telemetry received:", data);
    onTelemetry(data);
  });

  connection.onreconnecting(() => onConnectionChange(false));
  connection.onreconnected(() => onConnectionChange(true));
  connection.onclose((error) => {
    console.error("SignalR closed:", error);
    onConnectionChange(false);
  });

  connection
    .start()
    .then(() => {
      console.log("SignalR connected successfully");
      onConnectionChange(true);
    })
    .catch((error) => {
      console.error("SignalR connection failed:", error);
      onConnectionChange(false);
    });

  return connection;
}