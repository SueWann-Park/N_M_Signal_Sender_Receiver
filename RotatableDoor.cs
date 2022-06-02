using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableDoor : SignalReceiver
{
    Coroutine lastRoutine;
    float currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = 0;
    }
    public override void ReceiveOn()
    {
        if (isOn == true)
            return;

        base.ReceiveOn();

        if(lastRoutine != null)
        {
            StopCoroutine(lastRoutine);
            lastRoutine = null;
        }
        lastRoutine = StartCoroutine(RotateAndDisappear());
    }
    private IEnumerator RotateAndDisappear()
    {
        for(float i = currentAngle; i < 90; i+= 1)
        {
            transform.Rotate(0, 1, 0);
            yield return new WaitForFixedUpdate();
        }
    }

    public override void ReceiveOff()
    {
        if (isOn == false)
            return;

        base.ReceiveOff();

        if(lastRoutine != null)
        {
            StopCoroutine(lastRoutine);
            lastRoutine = null;
        }
        lastRoutine = StartCoroutine(RotateAndAppear());
    }

    private IEnumerator RotateAndAppear()
    {
        for(float i = currentAngle; i>0; i-= 1)
        {
            transform.Rotate(0, -1, 0);
            yield return new WaitForFixedUpdate();
        }
    }
}
