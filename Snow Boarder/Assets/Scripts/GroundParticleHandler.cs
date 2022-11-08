using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParticleHandler : MonoBehaviour
{
    public ParticleSystem groundEffect;
    public float groundTorque = 1f;
    public float airTorque = 5f;
    private bool isGrounded = false;
    void OnCollisionExit2D()
    {
        groundEffect.Stop();
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        groundEffect.Play();
        isGrounded = true;
    }

    public float GetTorque() => isGrounded ? groundTorque : airTorque;
    public bool IsTouchingGround() => isGrounded;
}
