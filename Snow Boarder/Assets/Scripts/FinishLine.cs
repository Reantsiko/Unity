using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : LevelManagement
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
            StartCoroutine(ResetLevel());
    }
}
