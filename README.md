🛠️ Real-Time 3D Underground Mine Digital Twin for Safety Monitoring

📌 Overview

This project is a **real-time industrial monitoring system** that simulates an underground mine environment and visualizes it in a **3D digital twin**.

It demonstrates how modern mining systems monitor:

* Worker safety
* Equipment health
* Environmental conditions (gas levels)
* Proximity risks

---

🎯 Objectives

* Simulate real-time industrial telemetry
* Visualize mine operations using 3D graphics
* Detect safety risks (proximity, gas, equipment faults)
* Demonstrate a scalable full-stack architecture

---

🏗️ System Architecture

```text
C# Simulation Service
        ↓
SignalR (WebSocket)
        ↓
React Frontend
        ↓
Three.js 3D Visualization
```

---

⚙️ Technologies Used

Backend

* C# ASP.NET Core
* SignalR (real-time communication)
* Background Services
* Dependency Injection

Frontend

* React (Vite)
* Three.js (React Three Fiber)
* SignalR WebSocket client

Concepts

* Real-time systems
* Digital twin
* Industrial monitoring
* Event-driven architecture

---

🔄 How the System Works

1. Data Simulation (Backend)

A background service (`MineSimulationService`) continuously generates:

* Worker positions
* Equipment status (temperature, speed, vibration)
* Gas sensor readings (methane, CO, oxygen)
* Alerts

---

2. Real-Time Communication


The system uses:


via **SignalR**, sending updates every ~1.5 seconds.

---

3. Frontend Processing

The React frontend:

* Connects to the SignalR hub
* Receives telemetry data
* Stores it in state
* Updates UI in real time

---

4. 3D Digital Twin (Three.js)

The system renders:

* Underground tunnel
* Workers (real-time movement)
* Mining equipment (loader + conveyor)
* Gas sensors
* Danger zones

Dynamic behavior:

| Condition           | Effect                |
| ------------------- | --------------------- |
| High methane        | Sensor turns red      |
| High temperature    | Equipment shows fault |
| Worker near machine | Danger zone alert     |
| Speed changes       | Equipment updates     |

---

5. Alert System

The backend generates alerts for:

* 🚨 Proximity risk
* ⚠ Equipment faults
* ☣ Gas dangers


---

📊 Key Features

* ✅ Real-time data streaming (SignalR)
* ✅ 3D underground visualization
* ✅ Worker tracking
* ✅ Equipment monitoring
* ✅ Gas/environment monitoring
* ✅ Proximity detection
* ✅ Alert system
* ✅ Interactive dashboard

---

📁 Project Structure

```text
backend/
  MineMonitor.Api/
    Controllers/
    Hubs/
    Models/
    Services/

frontend/
  mine-digital-twin-ui/
    components/
    hooks/
    services/
    utils/
```

---



Open App

```
http://localhost:5173
```

---

📸 Screenshots


![3D View](https://github.com/user-attachments/assets/df98a478-83b9-4f0a-aaf9-0c8119ea3015)

![Dashboard](https://github.com/user-attachments/assets/91e3751c-b7dd-4605-8b4d-efabd52170ed)



🔌 Industrial Relevance

This project mimics real-world systems:

| Real System         | This Project       |
| ------------------- | ------------------ |
| Sensors             | Simulation service |
| IoT devices         | Backend logic      |
| SCADA dashboards    | React UI           |
| Real-time protocols | SignalR            |




