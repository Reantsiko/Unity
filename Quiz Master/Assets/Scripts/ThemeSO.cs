using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Theme", fileName = "Theme ")]
public class ThemeSO : ScriptableObject
{
    [SerializeField] private string theme;
    [SerializeField] private List<QuestionSO> questions;

    public string GetThemeName() => theme;
    public QuestionSO GetQuestion(int index) => questions[index];
    public List<QuestionSO> GetQuestions() => questions;

    public void SetTheme(string toSet) 
    {
        theme = toSet;
        questions = new List<QuestionSO>();
    }
    public void AddQuestion(QuestionSO toAdd)
    {
        if (questions == null)
            questions = new List<QuestionSO>();
        questions.Add(toAdd);
    }
}
