using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float steerSpeed = 1f;
    public float moveSpeed = 1f;

    private void Update()
    {
        var moveDir = Input.GetAxis("Vertical");
        var turnDir = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(0, moveSpeed * moveDir) * Time.deltaTime);
        transform.Rotate(new Vector3(0,0, steerSpeed * -turnDir) * Time.deltaTime);
    }
}
