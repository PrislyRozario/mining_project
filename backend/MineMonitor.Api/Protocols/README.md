# Protocol Layer

This folder is intentionally included to show where real industrial protocol adapters would be added.

Suggested extensions:
- MQTT adapter: subscribe to mine sensor topics.
- OPC UA adapter: read equipment tags from PLC/SCADA systems.
- Modbus adapter: read registers from industrial devices.

For the 3-day demo, the backend uses a C# simulation service and SignalR to stream telemetry to the frontend.
