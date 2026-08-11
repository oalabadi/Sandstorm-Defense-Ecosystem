# Sandstorm Defense Ecosystem

A 3D UnityEngine project for simulating autonomous desert afforestation irrigated by drones to protect highways and infrastructure from sandstorms.

Rather than relying on static assets, this testbed utilizes code-driven procedural generation and algorithmic geometry to dynamically construct flora based on environmental parameters. Combined with spatial instancing and simulated drone raycasting, this framework serves as a scalable prototype for evaluating automated irrigation logistics and large-scale desert afforestation strategies.

 ## Simulation Demo

*<img width="800" height="365" alt="SDS Demo" src="https://github.com/user-attachments/assets/9f607d09-17e6-4caf-95d7-8b46886f4cf5" />*

## Play the Demo

You can experience the compiled simulation directly via itch.io:
**[Play the Sandstorm Defense Ecosystem on itch.io](https://thunderx7.itch.io/sandstorm-defense-system)**

## Core Technical Features

### 1. Procedural Botany & Algorithmic Geometry
Plants in this 3D simulation are generated at runtime using C# mathematical loops and procedural branching to ensure that no two plants are mathematically identical. 

### 2. Environmental Simulation & Hydration
The ecosystem tracks and implements varied hydration levels across the generated vegetation, simulating realistic environmental needs. The simulation also features procedural car generation to accurately model the highway infrastructure being protected.

### 3. Simulated Drone Scanning
To mimic real-world remote sensing, the engine features a custom raycast pipeline:
* Fires continuous physics raycasts per frame.
* Detects environmental geometry, vehicles, and procedural foliage.
* Logs critically dehydrated branches to an external dataset file for future processing.

## Current Development Roadmap

- [x] Procedural branch generation
- [x] Implement varied hydration levels
- [x] Procedural car generation
- [x] Sun intensity and Dehydration rate
- [x] Hover on branch to see its hydration level
- [x] Drone Stations
- [x] Drone scanning and logging critical branches to dataset file
- [x] User settings for sun intensity and irrigation rate

## Future Development

- [ ] Program autonomous drone pathfinding to read dataset files and dispatch targeted irrigation
- [ ] Implement Multi-Agent Reinforcement Learning (MARL) for optimized fleet coordination
- [ ] Develop an alignment diagram mapping procedural tree colors directly to NDVI levels utilizing green, yellow, and red/brown indicators
- [ ] Integrate sandstorm particle physics to simulate wind velocity reduction across the procedural vegetation barrier

---
**Author:** Osama Alabbadi  
**University:** Prince Mohammad Bin Fahd University (Software Engineering)  
**Contact:** osamababadi@gmail.com | [GitHub](https://github.com/oalabadi)
