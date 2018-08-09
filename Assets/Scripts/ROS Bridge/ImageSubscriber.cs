
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.sensor_msgs;
using SimpleJSON;
using UnityEngine;

public class ImageSubscriber : ROSBridgeSubscriber {
    public static CompressedImageMsg image = null;

    // These two are important
    public new static string GetMessageTopic() {
        //return "/camera/depth_registered/sw_registered/image_rect_raw/compressed";
        return "/camera/color/image_raw/compressed";
        //return "/camera_rgb/image_raw/compressed";
    }

    public new static string GetMessageType() {
        return "sensor_msgs/CompressedImage";
    }

    // Important function (I think, converting json to PoseMsg)
    public new static ROSBridgeMsg ParseMessage(JSONNode msg) {
        return new CompressedImageMsg(msg);
    }

    // This function should fire on each ros message
    public new static void CallBack(ROSBridgeMsg msg) {

        image = (CompressedImageMsg) msg;
    }
}