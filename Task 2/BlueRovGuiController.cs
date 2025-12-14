using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class BlueRovGuiController : MonoBehaviour
{
    public string topicName = "/bluerov1/cmd_vel";
    public float linearSpeed = 0.5f;
    public float angularSpeed = 0.5f;
    public float verticalSpeed = 0.3f;

    private ROSConnection ros;
    private TwistMsg currentTwist;
    private bool isPublishing = false;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<TwistMsg>(topicName);
        currentTwist = new TwistMsg();
    }

    void Update()
    {

        if (isPublishing)
        {
            ros.Publish(topicName, currentTwist);
        }
    }



    public void MoveForward()
    {
        ResetTwist();
        currentTwist.linear.x = linearSpeed;
        isPublishing = true;
    }

    public void MoveBackward()
    {
        ResetTwist();
        currentTwist.linear.x = -linearSpeed;
        isPublishing = true;
    }

    public void RotateLeft()
    {
        ResetTwist();
        currentTwist.angular.z = angularSpeed;
        isPublishing = true;
    }

    public void RotateRight()
    {
        ResetTwist();
        currentTwist.angular.z = -angularSpeed;
        isPublishing = true;
    }

    public void MoveUp()
    {
        ResetTwist();
        currentTwist.linear.z = verticalSpeed;
        isPublishing = true;
    }

    public void MoveDown()
    {
        ResetTwist();
        currentTwist.linear.z = -verticalSpeed;
        isPublishing = true;
    }

    public void Stop()
    {
        ResetTwist();
        isPublishing = false;
        // Publish one last zero message to stop the robot dead
        ros.Publish(topicName, currentTwist);
    }

    private void ResetTwist()
    {
        currentTwist.linear.x = 0;
        currentTwist.linear.y = 0;
        currentTwist.linear.z = 0;
        currentTwist.angular.x = 0;
        currentTwist.angular.y = 0;
        currentTwist.angular.z = 0;
    }
}
