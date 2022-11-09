using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private List<Button> answerButtons;
    [SerializeField] List<QuestionSO> questions;
    [SerializeField] private float timeToAnswer = 30f;
    [SerializeField] private float timerAfterSelection = 5f;
    [SerializeField] private float timeBetweenQuestions = 3f;
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite selectedAnswerSprite;
    [SerializeField] private Timer timer;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private ScoreTextHandler scoreHandler;
    private int currentQuestionIndex = 0;
    private int selectedAnswer = -1;
    private int correctAnswers = 0;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        progressBar = FindObjectOfType<ProgressBar>();
        scoreHandler = FindObjectOfType<ScoreTextHandler>();
    }

    void Start()
    {
        StartCoroutine(SetupQuestion(false));
    }

    public IEnumerator SetupQuestion(bool isNewQuestion)
    {
        if (isNewQuestion)
            ResetUI();
        yield return new WaitForSeconds(1f);
        progressBar.SetImageFillAmount((float)(currentQuestionIndex + 1) / questions.Count);
        answerButtons.ForEach(b => HideShowButton(b, false));
        ChangeQuestionText($"{questions[currentQuestionIndex].GetQuestion()}");
        yield return new WaitForSeconds(2f);
        if (answerButtons != null)
        {
            for (int i = 0; i < answerButtons.Count; i++)
            {
                HideShowButton(answerButtons[i], true, questions[currentQuestionIndex].GetAnswer(i).GetAnswerString());
                yield return new WaitForSeconds(2f);
            }
        }
        SetButtonInteraction(true);
        timer.StartCountdownRoutine(timeToAnswer);
    }

    public void OnSelectedAnswer(int index) => OnSelectedAnswer(answerButtons[index]);
    public void OnSelectedAnswer(Button button)
    {
        if (!timer.isSelectedAnswerCountdown)
        {
            timer.isSelectedAnswerCountdown = true;
            timer.StartCountdownRoutine(timerAfterSelection);
            ChangeQuestionText($"{questions[currentQuestionIndex].GetQuestion()}\nAre you certain?");
        }
        selectedAnswer = answerButtons.IndexOf(button);
        for (int i = 0; i < answerButtons.Count; i++)
            answerButtons[i].image.sprite = i == selectedAnswer ? selectedAnswerSprite : defaultAnswerSprite;
    }

    public void ShowAnswerAfterSelection()
    {
        SetButtonInteraction(false);
        if (questions[currentQuestionIndex].GetAnswer(selectedAnswer).GetIsCorrect())
        {
            ChangeQuestionText($"{questions[currentQuestionIndex].GetQuestion()}\nYou guessed correctly!");
            answerButtons[selectedAnswer].image.color = Color.green;
            UpdateScore(true);
        }
        else
        {
            ChangeQuestionText($"{questions[currentQuestionIndex].GetQuestion()}\nWrong! The correct answer was:");
            answerButtons[selectedAnswer].image.color = Color.red;
            var correctIndex = questions[currentQuestionIndex].GetCorrectAnswerIndex();
            answerButtons[correctIndex].image.color = Color.green;
            UpdateScore(false);
        }
        StartCoroutine(LoadNextQuestion());
    }

    public void ShowAnswer()
    {
        SetButtonInteraction(false);
        ChangeQuestionText($"{questions[currentQuestionIndex].GetQuestion()}\nThe correct answer was:");
        var correctIndex = questions[currentQuestionIndex].GetCorrectAnswerIndex();
        answerButtons[correctIndex].image.color = Color.green;
        UpdateScore(false);
        StartCoroutine(LoadNextQuestion());
    }

    private void UpdateScore(bool isCorrect)
    {
        if (isCorrect)
            correctAnswers++;
        scoreHandler.UpdateText((float)correctAnswers / (currentQuestionIndex + 1));
    }

    private void HideShowButton(Button button, bool showButton, string textToSet = null)
    {
        button.image.enabled = showButton;
        var textUgui = button.GetComponentInChildren<TextMeshProUGUI>();
        textUgui.text = textToSet;
        textUgui.enabled = showButton;
    }

    private void ChangeQuestionText(string toSet)
    {
        if (questionText != null)
            questionText.text = toSet;
    }

    private void SetButtonInteraction(bool toSet) => answerButtons.ForEach(b => b.enabled = toSet);

    private void ResetUI()
    {
        answerButtons.ForEach(button => {
            button.image.color = Color.white;
            button.image.sprite = defaultAnswerSprite;
        });
    }

    private IEnumerator LoadNextQuestion()
    {
        currentQuestionIndex++;
        yield return new WaitForSecondsRealtime(timeBetweenQuestions);
        if (currentQuestionIndex < questions.Count)
        {
            timer.Reset();
            StartCoroutine(SetupQuestion(true));
        }
    }
}
