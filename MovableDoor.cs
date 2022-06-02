using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableDoor : SignalReceiver
{
    Coroutine lastRoutine;
    public float moveDist = 3.0f;
    public float moveUnit = 0.1f;
    float accum = 0;

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
        lastRoutine = StartCoroutine(MoveUp());
    }
    public override void ReceiveOff()
    {
        if (isOn == false)
            return;

        base.ReceiveOff();

        if (lastRoutine != null)
        {
            StopCoroutine(lastRoutine);
            lastRoutine = null;
        }
        lastRoutine = StartCoroutine(MoveDown());
    }

    private IEnumerator MoveUp()
    {
        for(; ;)
        {
            this.transform.position += Vector3.up * moveUnit;
            accum += moveUnit;

            if (accum > moveDist)
                break;

            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator MoveDown()
    {
        for (; ; )
        {
            this.transform.position += Vector3.down * moveUnit;
            accum -= moveUnit;

            if (accum < 0)
                break;

            yield return new WaitForFixedUpdate();
        }
    }



}
