using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : ImageHandler
{
    private bool hasColorChanged = false;
    private bool loadNextQuestion = false;
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
        if (loadNextQuestion)
            ChangeColor(Color.white);
        var waiter = new WaitForEndOfFrame();
        float timer = startTime;
        SetImageFillAmount(timer / startTime);
        while (timer > 0)
        {
            if (timer < 6 && !hasColorChanged && !loadNextQuestion)
            {
                hasColorChanged = true;
                ChangeColor(Color.red);
            }
            yield return waiter;
            timer -= Time.deltaTime;
            SetImageFillAmount(timer / startTime);
        }
        if (!loadNextQuestion)
        {
            if (isSelectedAnswerCountdown)
                quiz.ShowAnswerAfterSelection();
            else
                quiz.ShowAnswer();
        }
        else
            quiz.LoadNextQuestion();
        Debug.Log($"Timer has expired");
    }

    public void StartCountdownRoutine(float timeToSet, bool isNewQuestion = false)
    {
        if (countDownRoutine != null)
        {
            StopCoroutine(countDownRoutine);
            countDownRoutine = null;
        }
        loadNextQuestion = isNewQuestion;
        countDownRoutine = StartCoroutine(TimerCountdown(timeToSet));
    }
    public void Reset()
    {
        isSelectedAnswerCountdown = false;
        loadNextQuestion = false;
        hasColorChanged = false;
        ChangeColor(Color.white);
    }
}
