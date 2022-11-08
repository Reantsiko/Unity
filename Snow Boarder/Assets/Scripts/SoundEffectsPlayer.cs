using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioClip finishSFX;
    public AudioClip crashSFX;
    private AudioSource listener;

    void Start() => listener = GetComponent<AudioSource>();

    public void PlaySFX(bool isCrash) => listener.PlayOneShot(isCrash ? crashSFX : finishSFX);
}
