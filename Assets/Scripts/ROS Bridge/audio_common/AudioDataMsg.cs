using SimpleJSON;
using ROSBridgeLib.std_msgs;
using UnityEngine;

/**
 * Define a Image message.
 *  
 * @author Mathias Ciarlo Thorstensen
 */

namespace ROSBridgeLib {
    namespace sensor_msgs {
        public class AudioDataMsg : ROSBridgeMsg {
            private byte[] _data;

            public AudioDataMsg(JSONNode msg) {
                _data = System.Convert.FromBase64String(msg["data"]);
                //Debug.Log(msg["data"]);
                //Debug.Log(_data);
            }

            public byte[] GetAudio() {
                return _data;
            }

            public static string GetMessageType() {
                return "audio_common_msgs/AudioData";
            }

            public override string ToString() {
                return "AudioData";
            }

            public override string ToYAMLString() {
                return "{}";
            }
        }
    }
}
