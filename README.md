# Weather Visualization – Unity Project

## Overview
This project is a Unity application that visualizes real-time and simulated weather conditions using a Dashboard UI and a 3D Visualization Scene.

The application fetches live weather data from the Open-Meteo API or generates simulated weather data for testing purposes. Weather conditions dynamically affect the 3D scene using Addressables-loaded visual effects.

---

## Features
- Finite State Machine (FSM) managing application flow
- Dashboard UI displaying:
  - Temperature
  - Weather Condition
  - Wind Speed
- Real-time weather fetching (Open-Meteo API)
- Simulation mode (manual weather override)
- Interactive 3D Visualization reacting to weather
- Addressables async FX loading
- FPS Counter for performance monitoring
- Location selector:
  - London
  - New York
  - Custom coordinates

---

## Requirements
- Unity 6.0 or newer
- TextMeshPro
- Addressables Package
- Internet connection (for Live Mode)

---

## Architecture Overview

### Core Systems
- **GameManager**: Global application manager
- **WeatherSystem**: Stores weather state and events
- **StateMachine**: Controls Dashboard / Visualization states
- **Weather Services**:
  - OpenMeteoWeatherService (Live Mode)
  - SimulationWeatherService (Simulation Mode)

### Views
#### Dashboard View
Displays current weather data and allows:
- Simulation Mode activation
- Live Weather Requests
- Navigation to Visualization View

#### Visualization View
3D scene reacts to weather:
- Clear → Bright environment
- Rain → Rain particle FX
- Snow → Snow particle FX + cold lighting

---

## How to Use

### Live Mode
1. Select location from dropdown:
   - London
   - New York
   - Custom
2. If Custom, enter latitude and longitude
3. Click **Weather** to fetch live data

### Simulation Mode
Use simulation buttons to force:
- Clear
- Rain
- Snow

### Navigation
- "To Visualization" → enter 3D View
- "Back" → return to Dashboard

---

## Technical Notes
- Weather data is retrieved from Open-Meteo API
- WeatherCode values are mapped internally to:
  - Clear
  - Rain
  - Snow
- Addressables load weather FX asynchronously only when required
- Weather updates propagate through an event-driven WeatherContext system
- FSM manages View lifecycle and activation

---

## Project Structure

Assets/
├── 01_Scripts/
│   ├── Core
│   ├── Location
│   ├── Weather
│   ├── StateMachine
│   ├── Services
│   ├── UI
│   └── Views
│
├── 02_Prefabs/
│   └── WeatherFX
│
└── 03_Scenes/
    └── MainScene