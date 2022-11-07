using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : LevelManagement
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
            StartCoroutine(ResetLevel());
    }
}
