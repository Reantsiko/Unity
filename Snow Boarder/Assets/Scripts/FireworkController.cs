using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkController : MonoBehaviour
{
    public ParticleSystem launch;
    public ParticleSystem fireworks;
    public float fireworksDelay = .7f;
    public IEnumerator PlayFireworks()
    {
        launch.Play();
        yield return new WaitForSeconds(fireworksDelay);
        fireworks.Play();
    }
}
