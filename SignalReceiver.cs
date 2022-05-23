using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    [System.NonSerialized] public bool isActive;
    private bool isReceivingOn;
    private float startReceivingTime;

    protected float receiveTimeMinimumInterval = 0.1f;

    protected bool isReceivingOff;
    private void Start()
    {
        isActive = false;
        isReceivingOn = false;
    }

    protected virtual void FixedUpdate()
    {
        if (isReceivingOn == false)
            return;
        if(Time.time > startReceivingTime + receiveTimeMinimumInterval)
        {
            isReceivingOn = false;
            if (isReceivingOff == true)
            {
                isReceivingOff = false;
                ReceiveOff();
            }
        }
    }

    public virtual void ReceiveOn()
    {
        isActive = true;
        isReceivingOn = true;
        isReceivingOff = false;
        startReceivingTime = Time.time;
    }

    public virtual void ReceiveOff()
    {
        if(isReceivingOn == true)
        {
            isReceivingOff = true;
            return;
        }
        isActive = false;
    }
}
