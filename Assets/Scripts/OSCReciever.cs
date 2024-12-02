using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCReciever : MonoBehaviour
{
    public OSC osc;
    public GameObject Dot;
    public float FloatY;
    public float FloatX;
   

    // Use this for initialization
    void Start()
    {
        osc.SetAddressHandler("/randomy", OnReceiveRandomY);
        osc.SetAddressHandler("/randomx", OnReceiveRandomX);
    }


    void OnReceiveRandomY(OscMessage message)
    {
        FloatY = message.GetFloat(0);
        print("RandomFloatY sent from python script: " + FloatY);
    }

    void OnReceiveRandomX(OscMessage message)
    {
        FloatX = message.GetFloat(0);
        print("RandomFloatX sent from python script: " + FloatX);
    }

}
