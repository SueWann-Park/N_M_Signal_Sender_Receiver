using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalSender : MonoBehaviour
{
    public SignalReceiver[] receivers;
    public int colorID = 0;

    public virtual void SendOn()
    {
        foreach (SignalReceiver r in receivers)
        {
            r.ReceiveOn();
        }
    }

    public virtual void SendOff()
    {
        foreach (SignalReceiver r in receivers)
        {
            r.ReceiveOff();
        }
    }
}
