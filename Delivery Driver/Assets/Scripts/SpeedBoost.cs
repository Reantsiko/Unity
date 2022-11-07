using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public List<float> speedToAdd = new List<float>{1,3,5};
    public List<SpriteRenderer> sprites;
    
    private int index = 1;
    
    private void OnEnable()
    {
        GeneratePowerUp();
    }

    public float GetSpeedBonus() => speedToAdd[index];

    private void GeneratePowerUp()
    {
        index = Random.Range(1,4);
        for (int i = 0; i < sprites.Count; i++)
            sprites[i].gameObject.SetActive(i + 1 <= index);
    }
}
