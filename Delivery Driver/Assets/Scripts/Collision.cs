using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"Collided with {collider.gameObject.name}");
        Destroy(collider.gameObject);
    }
}
