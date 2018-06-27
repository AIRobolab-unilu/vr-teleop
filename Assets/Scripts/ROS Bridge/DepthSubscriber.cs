
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.sensor_msgs;
using SimpleJSON;
using UnityEngine;

public class DepthSubscriber : ROSBridgeSubscriber
{
    public static PointCloud2Msg cloud = null;

    // These two are important
    public new static string GetMessageTopic()
    {
        return "/camera/depth_registered/points";
    }

    public new static string GetMessageType()
    {
        return "sensor_msgs/PointCloud2";
    }

    // Important function (I think, converting json to PoseMsg)
    public new static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        Debug.Log("constructing it from " + msg);
        return new PointCloud2Msg(msg);
    }

    // This function should fire on each ros message
    public new static void CallBack(ROSBridgeMsg msg)
    {

        cloud = (PointCloud2Msg)msg;
        //Debug.Log("image received");

        //Debug.Log("Here is the message received " + msg);

        // Update ball position, or whatever
        //ball.x = msg.x; // Check msg definition in rosbridgelib
        //ball.y = msg.y;
        //ball.z = msg.z;
    }
}