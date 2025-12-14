# Unity Underwater Simulation Server (BlueROV)

**Student:** Muhammad Azka Bintang Pramudya  
**Course:** SJO036 - UJI - Telerobotics and HRI (2025-2026)

## Project Overview

This project implements a bi-directional simulation bridge between Unity (HDRP) and ROS 2 Humble. It simulates a BlueROV underwater vehicle within a physics-enabled pool environment, allowing for remote teleoperation and visual feedback via ROS topics.

## Repository Structure

```
├── Unity_Source/           # The complete Unity Project (Assets, Packages, Settings)
├── ROS_Source/             # ROS 2 Python scripts and launch configurations
├── Task1/                  # Specific documentation and demo for Camera Task
├── Task2/                  # Specific documentation and demo for GUI Task
├── videos/                 # Demonstration videos for both tasks
└── README.md               # This file
```

##  Prerequisites

- **Unity:** Unity 6 (or 2022.2+ HDRP)
- **OS:** Ubuntu 22.04 LTS
- **ROS Distribution:** ROS 2 Humble Hawksbill
- **Dependencies:** `ros-humble-ros-tcp-endpoint`, `ros-humble-image-transport-plugins`

##  Tasks Implemented

### Task 1: Camera Visualization Bridge

A system to capture the BlueROV's front camera feed in Unity, compress it, and stream it to ROS 2 for visualization.

- **Topic:** `/bluerov1/camera/compressed`
- **Key Script:** `BlueRovCameraPublisher.cs`
- **Demo:** `videos/demo.webm`
- **Verification:** Visualized in RVIZ2 using the compressed image transport

### Task 2: Integrated GUI & Virtual Joystick

An in-simulation Graphical User Interface (GUI) that allows for full robot control without external terminals.

- **Features:** On-screen buttons (FWD, BWD, Turn, Up/Down) and a real-time CCTV monitor feed
- **Topic:** `/bluerov1/cmd_vel`
- **Key Script:** `BlueRovGuiController.cs`
- **Demo:** `videos/demo.webm`

## Quick Start

1. **Launch Unity:** Open the project and press Play
2. **Start Connection:** Run `ros2 run ros_tcp_endpoint default_server_endpoint`
3. **Run Task 1:** Open RVIZ2 and subscribe to the compressed camera topic
4. **Run Task 2:** Use the on-screen buttons in the Unity Game View to drive the robot


