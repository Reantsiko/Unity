using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private Button themeButtonPrefab;
    [SerializeField] private List<ThemeSO> themes;
    [SerializeField] private Transform buttonParent;
    [SerializeField] private Quiz quiz;

    private void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
    }

    private void Start()
    {
        if (buttonParent == null)
        {
            Debug.LogError($"Buttonparent is null");
            return;
        }
        CreateRandomTheme(3);
        CreateRandomTheme(5);
        CreateRandomTheme(8);
        themes.ForEach(t => {
            var b = Instantiate(themeButtonPrefab, buttonParent);
            b.GetComponentInChildren<TextMeshProUGUI>().text = t.GetThemeName();
            b.onClick.AddListener(() => {
                Debug.Log($"Click!");
                LoadQuiz(t);
            });
        });
    }

    private void LoadQuiz(ThemeSO theme)
    {
        quiz.gameObject.SetActive(true);
        quiz.PrepareQuiz(theme);
        gameObject.SetActive(false);
    }

    private void CreateRandomTheme(int questionAmount)
    {
        ThemeSO randomTheme = ScriptableObject.CreateInstance<ThemeSO>();
        randomTheme.SetTheme($"Random {questionAmount}");
        while (randomTheme.GetQuestions().Count < questionAmount)
        {
            int themeIndex = Random.Range(0, themes.Count);
            int questionIndex = Random.Range(0, themes[themeIndex].GetQuestions().Count);
            QuestionSO question = themes[themeIndex].GetQuestion(questionIndex);
            if (!randomTheme.GetQuestions().Contains(question))
                randomTheme.AddQuestion(question);
        }
        themes.Add(randomTheme);
    }
}
