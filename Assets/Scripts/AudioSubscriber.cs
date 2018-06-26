// Ball subscriber:
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.sensor_msgs;
using ROSBridgeLib.std_msgs;
using SimpleJSON;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AudioSubscriber : ROSBridgeSubscriber {
    public static AudioDataMsg audio = null;
    public static AudioSource audioSource;

    public new static string GetMessageTopic() {
        return "/teleop/audio";
    }

    public new static string GetMessageType() {
        return "audio_common_msgs/AudioData";
    }

    // Important function (I think, converting json to PoseMsg)
    public new static ROSBridgeMsg ParseMessage(JSONNode msg) {
        return new AudioDataMsg(msg);
    }

    // This function should fire on each ros message
    public new static void CallBack(ROSBridgeMsg msg) {
        audio = (AudioDataMsg) msg;

        File.WriteAllBytes("Assets/Resources/test.wav", audio.GetAudio());
        
        audioSource.volume = 1;
        AssetDatabase.ImportAsset("Assets/Resources/test.wav");
        AudioClip clip1 = Resources.Load<AudioClip>("test");
        //Debug.Log(clip1);
        //Debug.Log(clip1.length);
        audioSource.PlayOneShot(clip1);

        //Debug.Log("GOT ONE");

        // Debug.Log("audio received");
    }
}