﻿using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.std_msgs;
using SimpleJSON;

public class GesturePublisher : ROSBridgePublisher {

    // The following three functions are important
    public new static string GetMessageTopic() {
        return "/qt_movement/playGestureFromFile";
        //return "/b";
    }

    public new static string GetMessageType() {
        return "std_msgs/String";
    }

    public static string ToYAMLString(StringMsg msg) {
        return msg.ToYAMLString();
    }

    public static ROSBridgeMsg ParseMessage(JSONNode msg) {
        return new StringMsg(msg);
    }
        
 }

