using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : LevelManagement
{
    public ParticleSystem crashParticles;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            sfxPlayer.PlaySFX(true);
            if (rb != null)
                rb.simulated = false;
            crashParticles.Play();
            StartCoroutine(ResetLevel());
        }
    }
}
