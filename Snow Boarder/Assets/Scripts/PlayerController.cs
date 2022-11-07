using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float torque = 1f;
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.AddTorque(Input.GetKey(KeyCode.D) ? -torque : Input.GetKey(KeyCode.A) ? torque : 0);
        // if (Input.GetKey(KeyCode.D))
        //     rBody.AddTorque(-torque);
        // else if (Input.GetKey(KeyCode.A))
        //     rBody.AddTorque(torque);
    }
}
