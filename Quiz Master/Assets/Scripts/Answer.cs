using UnityEngine;
[System.Serializable]
public class Answer
{
    [SerializeField] private string answer;
    [SerializeField] private bool isCorrect;

    public string GetAnswerString() => answer;
    public bool GetIsCorrect() => isCorrect;
}