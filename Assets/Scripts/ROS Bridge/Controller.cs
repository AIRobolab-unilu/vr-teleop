using PointCloud;
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.sensor_msgs;
using ROSBridgeLib.std_msgs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;  
using WWUtils.Audio;

public class Controller : MonoBehaviour {

    public string ip;

    private ROSBridgeWebSocketConnection ros = null;
    private Sprite mySprite;
    private SpriteRenderer sr;

    static byte[] RIFF_HEADER = new byte[] { 0x52, 0x49, 0x46, 0x46 };
    static byte[] FORMAT_WAVE = new byte[] { 0x57, 0x41, 0x56, 0x45 };
    static byte[] FORMAT_TAG = new byte[] { 0x66, 0x6d, 0x74, 0x20 };
    static byte[] AUDIO_FORMAT = new byte[] { 0x01, 0x00 };
    static byte[] SUBCHUNK_ID = new byte[] { 0x64, 0x61, 0x74, 0x61 };
    private const int BYTES_PER_SAMPLE = 2;

    byte[] oldAudio = null;
    int counter = 0;
    int i = 0;

    void Awake() {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);

        transform.position = new Vector3(1.5f, 1.5f, 0.0f);
    }


    void Start() {
        Debug.Log("starting");
        // Where the rosbridge instance is running, could be localhost, or some external IP
        //ros = new ROSBridgeWebSocketConnection("ws://10.212.232.15", 9090);
        //ros = new ROSBridgeWebSocketConnection("ws://10.212.232.16", 9090);
        ros = new ROSBridgeWebSocketConnection("ws://"+ip, 9090);
        

        // Add subscribers and publishers (if any)
        ros.AddSubscriber(typeof(ImageSubscriber));
        ros.AddSubscriber(typeof(StatusSubscriber));
        //ros.AddSubscriber(typeof(DepthSubscriber));
        ros.AddSubscriber(typeof(AudioSubscriber));
        ros.AddPublisher(typeof(MotorPublisher));
        //ros.AddPublisher(typeof(BallControlPublisher));

        AudioSubscriber.audioSource = GetComponent<AudioSource>();

        // Fire up the subscriber(s) and publisher(s)
        Debug.Log("connecting ...");
        ros.Connect();
        Debug.Log("connected");

        // And in some other class where the ball is controlled:
        //TwistMsg msg = new TwistMsg(new Vector3Msg(10, 30, 50), new Vector3Msg(50, 400, 30)); // Circa

        // Publish it (ros is the object defined in the first class)
        //ros.Publish(BallControlPublisher.GetMessageTopic(), msg);
    }

    // Extremely important to disconnect from ROS. Otherwise packets continue to flow
    void OnApplicationQuit() {
        if (ros != null) {
            ros.Disconnect();
        }
    }
    // Update is called once per frame in Unity
    void Update() {

        //Debug.Log("New frame :");

        // And in some other class where the ball is controlled:
        TwistMsg msg = new TwistMsg(new Vector3Msg(10, 20, 30), new Vector3Msg(0, 0, 0)); // Circa

        // Publish it (ros is the object defined in the first class)
        //ros.Publish(BallControlPublisher.GetMessageTopic(), msg);
        //ros.Publish(MotorPublisher.GetMessageTopic(), new StringMsg("i neck_h 5"));


        if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("i neck_h 5");
            ros.Publish(MotorPublisher.GetMessageTopic(), new StringMsg("i neck_h -5"));
            Debug.Log("ok");
            
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("i neck_h -5");
            ros.Publish(MotorPublisher.GetMessageTopic(), new StringMsg("i neck_h 5"));
            Debug.Log("ok");

        }
        //int size = (int)System.Math.Sqrt(ImageSubscriber.image.GetImage().Length);

        Texture2D texture = new Texture2D(2, 2);

        CompressedImageMsg image = ImageSubscriber.image;

        if (image != null) {
            texture.LoadImage(ImageSubscriber.image.GetImage());
            texture.Apply();
            sr.material.mainTexture = texture;
            mySprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            sr.sprite = mySprite;
        }
        else {
            //Debug.Log("no image stream");
        }

        if (DepthSubscriber.cloud != null) {
            //Debug.Log("wtf");
            //Debug.Log(DepthSubscriber.cloud);
            List<PointXYZRGB> points = (List<PointXYZRGB>)DepthSubscriber.cloud.GetCloud().Points;
            //Debug.Log(points.Count);
            //foreach (var point in points) {
                //Debug.Log(point.R + " | " + point.G + " | " + point.B + " ----- " + point.X + " | " + point.Y + " | " + point.Z);
            //}
        }
        else {
            //Debug.Log("no cloud stream weird");
        }

        //AudioDataMsg audioMsg = AudioSubscriber.audio;

        //if(audioMsg != null) {

        /*
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;


        string url = Application.dataPath + "/Scripts/test.wav";
        WWW www = new WWW(url);

        //audioSource.clip = www.GetAudioClip();



        //audioSource.Play();
        if (!audioSource.isPlaying) {
            AssetDatabase.ImportAsset("Assets/Resources/test.wav");
            AudioClip clip1 = Resources.Load<AudioClip>("test");
            //Debug.Log(clip1);
            //Debug.Log(clip1.length);
            audioSource.PlayOneShot(clip1);
            //Resources.UnloadAsset(clip1);
            //audioSource.Play();
            //Debug.Log("playing");

        }



        string strCmdText;
        //strCmdText = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
        //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

        byte[] tmp;
        if (oldAudio != null) {
            tmp = new byte[audioMsg.GetAudio().Length + oldAudio.Length];
            oldAudio.CopyTo(tmp, 0);
            audioMsg.GetAudio().CopyTo(tmp, oldAudio.Length);

            counter += 1;
        }
        else {
            tmp = audioMsg.GetAudio();
        }


        if(counter == 20000) {
            using (FileStream fs = new FileStream("Assets/MySound2.wav", FileMode.Create)) {
                //WriteHeader(fs, tmp.Length, 1, 16000);

                /*MemoryStream stream = new MemoryStream();

                stream.Write(tmp, 0, tmp.Length);

                WriteWavHeader(stream, false, 1, 16, 16000, tmp.Length);

                byte[] bytesArray = stream.ToArray();
                float[] floatArray = ConvertByteToFloat(bytesArray);

                AudioSource audioSource = GetComponent<AudioSource>();
                AudioClip audioClip = AudioClip.Create("testSound", floatArray.Length, 1, 16000, false);
                audioClip.SetData(floatArray, 0);

                audioSource.clip = audioClip;
                audioSource.Play();

                fs.Write(bytesArray, 0, bytesArray.Length);
                fs.Close();

                File.WriteAllBytes("Assets/Scripts/test.tmp", tmp);
                Debug.Log("written to disk");
                Debug.Log(tmp.GetValue(100));
                Debug.Log(tmp.GetValue(200));
                Debug.Log(tmp.GetValue(300));
                Debug.Log(tmp.GetValue(600));
                Debug.Log(tmp.GetValue(800));
            }

            //AudioSource audioSource = GetComponent<AudioSource>();
            //audioSource.Play();
        }

        /*MemoryStream stream = new MemoryStream();

        stream.Write(audioMsg.GetAudio(), 0, audioMsg.GetAudio().Length);

        WriteWavHeader(stream, false, 1, 16, 16000, audioMsg.GetAudio().Length);

        byte[] bytesArray = stream.ToArray();
        float[] floatArray = ConvertByteToFloat(bytesArray);

        AudioSource audioSource = GetComponent<AudioSource>();
        AudioClip audioClip = AudioClip.Create("testSound", floatArray.Length, 1, 16000, false);
        audioClip.SetData(floatArray, 0);

        audioSource.clip = audioClip;

        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
        */

        //oldAudio = tmp;

        //audioSource.Play(16000);

        //AudioClip audioClip = AudioClip.Create("testSound", audio.Length, 1, 16000, false);
        //audioClip.SetData(audio, 0);

        //AudioSource.PlayClipAtPoint(audioClip, new Vector3(100, 100, 0), 1.0f);


        /*WAV wav = new WAV(audioMsg.GetAudio());
        Debug.Log(wav);
        AudioClip audioClip = AudioClip.Create("testSound", wav.SampleCount, 1, wav.Frequency, false);
        audioClip.SetData(wav.LeftChannel, 0);

        AudioSource.PlayClipAtPoint(audioClip, new Vector3(100, 100, 0), 1.0f);*/
        //audio.clip = audioClip;
        //audio.Play();
        //}

        /*for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                int r = ImageSubscriber.image.GetImage()[texture.width * y + x];
                Color color = new Color()
                Color color = ((x & y) != 0 ? Color.white : Color.gray);
                texture.SetPixel(x, y, color);
            }
        }*/


        ros.Render();
    }

    // totalSampleCount needs to be the combined count of samples of all channels. So if the left and right channels contain 1000 samples each, then totalSampleCount should be 2000.
    // isFloatingPoint should only be true if the audio data is in 32-bit floating-point format.

    private void WriteWavHeader(MemoryStream stream, bool isFloatingPoint, ushort channelCount, ushort bitDepth, int sampleRate, int totalSampleCount) {
        stream.Position = 0;

        //Debug.Log(sampleRate * channelCount * (bitDepth / 8));

        // RIFF header.
        // Chunk ID.
        stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);

        // Chunk size.
        stream.Write(BitConverter.GetBytes(((bitDepth / 8) * totalSampleCount) + 36), 0, 4);

        // Format.
        stream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);



        // Sub-chunk 1.
        // Sub-chunk 1 ID.
        stream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);

        // Sub-chunk 1 size.
        stream.Write(BitConverter.GetBytes(16), 0, 4);

        // Audio format (floating point (3) or PCM (1)). Any other format indicates compression.
        stream.Write(BitConverter.GetBytes((ushort)(isFloatingPoint ? 3 : 1)), 0, 2);

        // Channels.
        stream.Write(BitConverter.GetBytes(channelCount), 0, 2);

        // Sample rate.
        stream.Write(BitConverter.GetBytes(sampleRate), 0, 4);

        // Bytes rate.
        //stream.Write(BitConverter.GetBytes(192), 0, 4);
        stream.Write(BitConverter.GetBytes(sampleRate * channelCount * (bitDepth / 8)), 0, 4);

        // Block align.
        stream.Write(BitConverter.GetBytes((ushort)channelCount * (bitDepth / 8)), 0, 2);

        // Bits per sample.
        stream.Write(BitConverter.GetBytes(bitDepth), 0, 2);



        // Sub-chunk 2.
        // Sub-chunk 2 ID.
        stream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);

        // Sub-chunk 2 size.
        stream.Write(BitConverter.GetBytes((bitDepth / 8) * totalSampleCount), 0, 4);
    }

    public static byte[] CreateSinWave(
        int sampleRate,
        double frequency,
        TimeSpan length,
        double magnitude
    ) {
        int sampleCount = (int)(((double)sampleRate) * length.TotalSeconds);
        short[] tempBuffer = new short[sampleCount];
        byte[] retVal = new byte[sampleCount * 2];
        double step = Math.PI * 2.0d / frequency;
        double current = 0;

        for (int i = 0; i < tempBuffer.Length; ++i) {
            tempBuffer[i] = (short)(Math.Sin(current) * magnitude * ((double)short.MaxValue));
            current += step;
        }

        Buffer.BlockCopy(tempBuffer, 0, retVal, 0, retVal.Length);
        return retVal;
    }

    public static void WriteHeader(
     System.IO.Stream targetStream,
     int byteStreamSize,
     int channelCount,
     int sampleRate) {
        int byteRate = sampleRate * channelCount * BYTES_PER_SAMPLE;
        int blockAlign = channelCount * BYTES_PER_SAMPLE;

        targetStream.Write(RIFF_HEADER, 0, RIFF_HEADER.Length);
        targetStream.Write(PackageInt(byteStreamSize + 42, 4), 0, 4);

        targetStream.Write(FORMAT_WAVE, 0, FORMAT_WAVE.Length);
        targetStream.Write(FORMAT_TAG, 0, FORMAT_TAG.Length);
        targetStream.Write(PackageInt(16, 4), 0, 4);//Subchunk1Size    

        targetStream.Write(AUDIO_FORMAT, 0, AUDIO_FORMAT.Length);//AudioFormat   
        targetStream.Write(PackageInt(channelCount, 2), 0, 2);
        targetStream.Write(PackageInt(sampleRate, 4), 0, 4);
        targetStream.Write(PackageInt(byteRate, 4), 0, 4);
        targetStream.Write(PackageInt(blockAlign, 2), 0, 2);
        targetStream.Write(PackageInt(BYTES_PER_SAMPLE * 8), 0, 2);
        //targetStream.Write(PackageInt(0,2), 0, 2);//Extra param size
        targetStream.Write(SUBCHUNK_ID, 0, SUBCHUNK_ID.Length);
        targetStream.Write(PackageInt(byteStreamSize, 4), 0, 4);
    }

    static byte[] PackageInt(int source, int length = 2) {
        if ((length != 2) && (length != 4))
            throw new ArgumentException("length must be either 2 or 4", "length");
        var retVal = new byte[length];
        retVal[0] = (byte)(source & 0xFF);
        retVal[1] = (byte)((source >> 8) & 0xFF);
        if (length == 4) {
            retVal[2] = (byte)((source >> 0x10) & 0xFF);
            retVal[3] = (byte)((source >> 0x18) & 0xFF);
        }
        return retVal;
    }

    private float[] ConvertByteToFloat(byte[] array) {
        float[] floatArr = new float[array.Length / 4];
        for (int i = 0; i < floatArr.Length; i++) {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array, i * 4, 4);
            floatArr[i] = BitConverter.ToSingle(array, i * 4) / 0x80000000;
            //floatArr[i] = BitConverter.ToSingle(array, i * 4);
        }
        return floatArr;
    }
}