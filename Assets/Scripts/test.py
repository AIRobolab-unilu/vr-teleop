#!/usr/bin/env python

import contextlib    
import wave

buff = None
counter = 0

def callback(data):
    global buff
    global counter
    
    if buff is None:
        buff = data.data
    else:
        buff += data.data
        counter += 1

    rospy.loginfo(rospy.get_caller_id() + "I heard %s", data.data)

    if counter == 200:
        with contextlib.closing(wave.open("test.wav", 'wb')) as wf:
            wf.setnchannels(1)
            wf.setsampwidth(2)
            wf.setframerate(16000)
            wf.writeframes(buff)

if __name__ == '__main__':
    fh = open('test.tmp', 'rb')
    ba = bytearray(fh.read())
    print(len(ba))
    print(ba[100])
    print(ba[200])
    print(ba[300])
    print(ba[600])
    print(ba[800])
    with contextlib.closing(wave.open("test.wav", 'wb')) as wf:
        wf.setnchannels(1)
        wf.setsampwidth(2)
        wf.setframerate(16000)
        wf.writeframes(ba)