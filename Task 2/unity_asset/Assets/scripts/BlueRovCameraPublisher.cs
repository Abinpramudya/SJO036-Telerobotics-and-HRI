using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;
using RosMessageTypes.Std;
using RosMessageTypes.BuiltinInterfaces;

public class BlueRovCameraPublisher : MonoBehaviour
{
    [Header("ROS Settings")]
    public string topicName = "/bluerov1/camera/compressed";
    public string frameId = "camera_link";
    [Range(1, 30)]
    public float publishFrequency = 10f; // Hz (Don't go too high or you'll lag)
    [Range(0, 100)]
    public int qualityLevel = 50; // JPG Quality (Lower = faster)

    [Header("Camera Settings")]
    public Camera targetCamera;
    public int resolutionWidth = 640;
    public int resolutionHeight = 480;

    private ROSConnection ros;
    private float timeElapsed;
    private float publishInterval;
    private Texture2D texture2D;
    private Rect rect;
    private RenderTexture renderTexture;

    void Start()
    {
        // 1. Get ROS Connection
        ros = ROSConnection.GetOrCreateInstance();
        
        // 2. Register the Publisher
        ros.RegisterPublisher<CompressedImageMsg>(topicName);

        // 3. Setup Timer
        publishInterval = 1.0f / publishFrequency;

        // 4. If no camera assigned, try to get component
        if (targetCamera == null)
        {
            targetCamera = GetComponent<Camera>();
        }

        // 5. Initialize Textures (Reusing them saves memory!)
        texture2D = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
        rect = new Rect(0, 0, resolutionWidth, resolutionHeight);
        renderTexture = new RenderTexture(resolutionWidth, resolutionHeight, 24);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= publishInterval)
        {
            PublishCameraImage();
            timeElapsed = 0;
        }
    }

    void PublishCameraImage()
    {
        // A. Point the camera to our temporary render texture
        targetCamera.targetTexture = renderTexture;
        
        // B. Render the camera manually
        targetCamera.Render();

        // C. Read the pixels from the Render Texture into our Texture2D
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(rect, 0, 0);
        texture2D.Apply();

        // D. Encode to JPG
        byte[] imageBytes = texture2D.EncodeToJPG(qualityLevel);

        // E. Construct the ROS Message
        CompressedImageMsg msg = new CompressedImageMsg();
        msg.header.frame_id = frameId;
        
        // (Optional: Add timestamp if needed, otherwise it sends 0)
        // msg.header.stamp = new TimeMsg(Clock.Now); 

        msg.format = "jpeg";
        msg.data = imageBytes;

        // F. Publish
        ros.Publish(topicName, msg);

        // G. Clean up references
        targetCamera.targetTexture = null;
        RenderTexture.active = null;
    }
}
