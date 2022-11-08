using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : ImageHandler
{
    public override void Start()
    {
        base.Start();
        SetImageFillAmount(0);
    }
}
