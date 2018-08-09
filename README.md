
# vr_teleop

This repository allows to connect to a ROS websocket bridge server and display audio + video through the Oculus Rift. The Oculus can also display informations on the robot and send command to the motors.
Here is the repository of the server running on the robot. https://github.com/AIRobolab-unilu/vr_teleop_server

## User 


To use this repository, a robot with [this program](https://github.com/AIRobolab-unilu/vr_teleop_server) is needed and a computer with the Oculus software with the hardware requirements. Then, the user needs to run this program
and use an headset and two touch controllers.

## Developer

This quick tutorial assumes that the you know how to code on Unity.

If someone wants to develop with this repository, here is some advices :

The ROS Bridge folder contains the classes to convert a ROS message to a C# class with the correct fields. Basic messages already exist, but it is possible to create your own custom messages by looking at the other classes.
This folder also contains a class named "Controller" which is used to manage the ROS Bridge part. On the beggining of the Start function, you can add a Subscriber or a ublisher with :

```csharp
os.AddSubscriber(typeof(SomeSubscriber));
ros.AddPublisher(typeof(SomePublisher));
```

With SomeSubscriber and SomePublisher which are classes created according the other publishers and subscribers. This publisher or subscriber is linked to a message and a topic. Like the message, there is several examples
which you can base yourself. A way to save the data, is to populate a field in the Subscriber, then to use it in the Controller Update, this is what I used for the audio and the video.

The InputManager is used to manage the differents inputs from the Keyboard, Touch Controllers and XBox Controller.

The folder UI Controller contains classes to work with the UI and draw the lines.

The target IP of the Robot can be modified in the GameObject named "Display" in the scene.