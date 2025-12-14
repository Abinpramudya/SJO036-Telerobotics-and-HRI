**Student:** Muhammad Azka Bintang Pramudya  
**Course:** SJO036 - UJI - Telerobotics and HRI (2025-2026)

## Description

This task implements a bridge to capture the BlueROV camera feed in Unity, compress it as a JPEG, and publish it to the ROS 2 topic `/bluerov1/camera/compressed`. This allows visual feedback from the simulation to be viewed in external ROS tools like RVIZ.

## Files

- `BlueRovCameraPublisher.cs`: The C# script attached to the BlueROV camera object in Unity
- `videos/demo.webm`: Video demonstration of the camera visualization working in RVIZ

## How to Run

### Unity Setup

Ensure the `BlueRovCameraPublisher` script is attached to the BlueROV camera GameObject and the "Target Camera" field is assigned. Press Play in the Unity Editor.

### ROS TCP Endpoint

Open a terminal and start the endpoint to enable communication:

```bash
ros2 run ros_tcp_endpoint default_server_endpoint
```

### Visualization

Open a second terminal and launch RVIZ:

```bash
rviz2
```

Configure the display:
- Add an Image display
- Set the Topic to `/bluerov1/camera/compressed`
- Set the Transport Hint to `compressed`

***

