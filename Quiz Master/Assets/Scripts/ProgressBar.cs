using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : ImageHandler
{
    public override void Awake()
    {
        base.Awake();
        SetImageFillAmount(0);
    }
}
