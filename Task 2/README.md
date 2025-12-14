# SJO036-Telerobotics-and-HRI Task 2: Unity GUI & Virtual Joystick

**Student:** Muhammad Azka Bintang Pramudya  
**Course:** SJO036 - UJI - Telerobotics and HRI (2025-2026)

## Description

This task implements an integrated Graphical User Interface (GUI) within Unity to control the BlueROV without needing an external terminal. It features a "Virtual Joystick" (on-screen buttons) for navigation and a real-time camera monitor feed directly on the canvas.

## Features

- **Virtual Joystick:** UI Buttons for Forward, Backward, Rotate Left/Right, and Depth control (Up/Down)
- **Hold-to-Move:** Implemented using EventTriggers to publish velocity commands continuously while buttons are pressed
- **Camera Monitor:** A RawImage display on the UI showing the robot's perspective
- **Direct ROS Publishing:** The UI controller publishes `geometry_msgs/Twist` directly to `/bluerov1/cmd_vel`

## Files

- `BlueRovGuiController.cs`: The C# script that handles UI events and ROS publishing
- `videos/videoname.webm`: Video demonstration of the GUI controlling the robot

## How to Run

### Unity Setup

- Ensure the `BlueRovGuiController` script is attached to a GameObject in the scene
- Verify the buttons on the Canvas are linked to the controller's functions (`MoveForward`, `RotateLeft`, etc.) via EventTriggers
- Press Play in the Unity Editor

### ROS TCP Endpoint

Open a terminal and start the endpoint to enable communication:

```bash
ros2 run ros_tcp_endpoint default_server_endpoint
```

### Operation

- Click and hold the buttons on the Unity Game View to move the robot
- Observe the robot's movement via the on-screen camera monitor

***

Would you like me to add a Dependencies or Controls Reference section?
