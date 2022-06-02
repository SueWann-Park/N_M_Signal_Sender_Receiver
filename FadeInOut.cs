using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : SignalReceiver
{
    Coroutine lastRoutine;
    SpriteRenderer sr;
    float currentAlpha;

    private void SetAlpha(float alpha)
    {
        Color c = sr.color;
        c.a = alpha;
        sr.color = c;
        currentAlpha = alpha;
    }

    private void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        lastRoutine = null;
        currentAlpha = sr.color.a;
    }

    public override void ReceiveOn()
    {
        if (isOn == true)
            return;

        base.ReceiveOn();

        if (lastRoutine != null)
        {
            StopCoroutine(lastRoutine);
            lastRoutine = null;
        }
        lastRoutine = StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        for(float a = currentAlpha; a<=1; a += 0.01f)
        {
            SetAlpha(a);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator FadeOut()
    {
        for (float a = currentAlpha; a >= 0; a -= 0.01f)
        {
            SetAlpha(a);
            yield return new WaitForFixedUpdate();
        }
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
        lastRoutine = StartCoroutine(FadeOut());
    }
}
