using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreTextHandler : MonoBehaviour
{
    TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        UpdateText(100f);
    }

    public void UpdateText(float score)
    {
        if (text == null) return;
        text.text = $"Score: {score}%";
    }
}
