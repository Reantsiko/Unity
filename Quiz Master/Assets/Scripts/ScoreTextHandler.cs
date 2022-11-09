using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreTextHandler : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        UpdateText(0);
    }

    public void UpdateText(float score)
    {
        if (text == null) return;
        text.text = $"Score: {Mathf.Floor(score * 100)}%";
    }
}
