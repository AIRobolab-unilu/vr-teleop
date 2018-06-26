// Ball subscriber:
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.sensor_msgs;
using ROSBridgeLib.std_msgs;
using SimpleJSON;
using UnityEngine;

public class WaveSubscriber : ROSBridgeSubscriber {
    public static UInt8Msg audio = null;

    public new static string GetMessageTopic() {
        return "/audio/wave";
    }

    public new static string GetMessageType() {
        return "std_msgs/UInt8";
    }

    // Important function (I think, converting json to PoseMsg)
    public new static ROSBridgeMsg ParseMessage(JSONNode msg) {
        return new AudioDataMsg(msg);
    }

    // This function should fire on each ros message
    public new static void CallBack(ROSBridgeMsg msg) {
        audio = (UInt8Msg) msg;
       // Debug.Log("audio received");
    }
}