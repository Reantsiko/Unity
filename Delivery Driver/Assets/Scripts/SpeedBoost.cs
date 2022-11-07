using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public List<float> speedToAdd = new List<float>{1,3,5};
    public List<SpriteRenderer> sprites;
    
    private int index = 1;
    private int positionIndex = 0;
    
    private void OnEnable()
    {
        GeneratePowerUp();
    }

    public float GetSpeedBonus() 
    {
        StartCoroutine(DisableObject());
        return speedToAdd[index];
    }

    private IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    public void SetPositionIndex(int indexToSet) => positionIndex = indexToSet;
    public int GetPositionIndex() => positionIndex;

    private void GeneratePowerUp()
    {
        index = Random.Range(1,4);
        for (int i = 0; i < sprites.Count; i++)
            sprites[i].gameObject.SetActive(i + 1 <= index);
    }
}
