using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FinishLine : LevelManagement
{
    public FireworkController fireWorks;
    private CinemachineVirtualCamera vc;
    
    void Start()
    {
        vc = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            sfxPlayer.PlaySFX(false);
            var rb = collider.GetComponent<Rigidbody2D>();
            rb.simulated = false;
            if (vc != null)
                vc.m_Lens.OrthographicSize = 12;
            StartCoroutine(fireWorks.PlayFireworks());
            StartCoroutine(ResetLevel());
        }
    }
}
