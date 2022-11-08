using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 20f;
    public float boostSpeed = 30f;
    public float slowSpeed = 10f;
    public float jumpForce = 1f;
    private Rigidbody2D rBody;
    private SurfaceEffector2D surface;
    private GroundParticleHandler groundParticleHandler;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rBody = GetComponent<Rigidbody2D>();
        surface = FindObjectOfType<SurfaceEffector2D>();
        groundParticleHandler = GetComponent<GroundParticleHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        // rBody.AddTorque(Input.GetKey(KeyCode.D) ? -torque : Input.GetKey(KeyCode.A) ? torque : 0);
        if (Input.GetKey(KeyCode.D))
        {
            rBody.AddTorque(-groundParticleHandler.GetTorque());
            surface.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rBody.AddTorque(groundParticleHandler.GetTorque());
            surface.speed = slowSpeed;
        }
        else
        {
            surface.speed = baseSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundParticleHandler.IsTouchingGround())
            rBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
    }
}
