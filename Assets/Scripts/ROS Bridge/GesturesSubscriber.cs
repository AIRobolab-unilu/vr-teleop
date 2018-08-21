
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.sensor_msgs;
using ROSBridgeLib.std_msgs;
using SimpleJSON;
using UnityEngine;

public class GesturesSubscriber : ROSBridgeSubscriber {

    private static string gestures;

    // These two are important
    public new static string GetMessageTopic() {
        //return "/camera/depth_registered/sw_registered/image_rect_raw/compressed";
        return "/teleop/gestures";
    }

    public new static string GetMessageType() {
        return "std_msgs/String";
    }

    // Important function (I think, converting json to PoseMsg)
    public new static ROSBridgeMsg ParseMessage(JSONNode msg) {
        return new StringMsg(msg);
    }

    // This function should fire on each ros message
    public new static void CallBack(ROSBridgeMsg msg) {

        StringMsg tmp = (StringMsg)msg;

        if (!gestures.Equals(tmp.GetData())) {

            gestures = tmp.GetData();

            GameManager.instance.UpdateGestures(tmp.GetData());
        }

        
        //Debug.Log("image received");

        //Debug.Log("Here is the message received " + msg);

        // Update ball position, or whatever
        //ball.x = msg.x; // Check msg definition in rosbridgelib
        //ball.y = msg.y;
        //ball.z = msg.z;
    }
}