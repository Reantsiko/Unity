using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [SerializeField]
    [TextArea(2,6)]
    private string question = "Enter new question text here";
    [SerializeField]
    private List<Answer> answers;

    public string GetQuestion() => question;
    public Answer GetAnswer(int index)
    {
        if (answers == null || index > answers.Count)
            return null;
        return answers[index];
    }
}
