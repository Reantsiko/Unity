using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : ImageHandler
{
    private bool hasColorChanged = false;
    public bool isSelectedAnswerCountdown;
    private Quiz quiz;
    private Coroutine countDownRoutine;
    public override void Awake()
    {
        base.Awake();
        quiz = FindObjectOfType<Quiz>();
    }

    public IEnumerator TimerCountdown(float startTime)
    {
        var waiter = new WaitForEndOfFrame();
        float timer = startTime;
        SetImageFillAmount(timer / startTime);
        while (timer > 0)
        {
            if (timer < 6 && !hasColorChanged)
            {
                hasColorChanged = true;
                ChangeColor(Color.red);
            }
            yield return waiter;
            timer -= Time.deltaTime;
            SetImageFillAmount(timer / startTime);
        }
        if (isSelectedAnswerCountdown)
            quiz.ShowAnswerAfterSelection();
        else
            quiz.ShowAnswer();
        Debug.Log($"Timer has expired");
    }

    public void StartCountdownRoutine(float timeToSet)
    {
        if (countDownRoutine != null)
        {
            StopCoroutine(countDownRoutine);
            countDownRoutine = null;
        }
        countDownRoutine = StartCoroutine(TimerCountdown(timeToSet));
    }
    public void Reset()
    {
        isSelectedAnswerCountdown = false;
        hasColorChanged = false;
        ChangeColor(Color.white);
    }
}
