using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageHandler : MonoBehaviour
{
    [SerializeField] private Image image;

    public virtual void Awake()
    {
        image = GetComponent<Image>();
    }
    
    public void SetImageFillAmount(float value) 
    {
        if (image != null)
            image.fillAmount = value;
        else
            Debug.LogError($"Image is empty");
    }

    public void ChangeColor(Color color)
    {
        if (color == null)
            return;
        image.color = color;
    }
}
