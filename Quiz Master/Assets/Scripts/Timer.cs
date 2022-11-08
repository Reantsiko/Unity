using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : ImageHandler
{
    public float timeLeft = 30;
    
    public override void Start()
    {
        base.Start();
        StartCoroutine(TimerCountdown());
    }

    public IEnumerator TimerCountdown()
    {
        var waiter = new WaitForSeconds(1f);
        float startAmount = timeLeft;
        while (timeLeft > 0)
        {
            yield return waiter;
            timeLeft--;
            SetImageFillAmount(timeLeft / startAmount);
        }
        Debug.Log($"Timer has expired");
    }
}
