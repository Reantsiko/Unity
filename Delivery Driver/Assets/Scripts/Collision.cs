using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage;
    Driver driver;

    void Start()
    {
        driver = GetComponent<Driver>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AI Car")
            Debug.Log("You hit a car!");
        if (driver != null)
            driver.moveSpeed = Mathf.Clamp(driver.moveSpeed - 1, 10, 50);
        Debug.Log(collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Package")
        {
            hasPackage = true;
            Debug.Log($"Picked up package");
        }
        if (collider.tag == "Delivery Point" && hasPackage)
        {
            hasPackage = false;
            Debug.Log($"Reached delivery point");
        }
        if (collider.tag == "Speed Boost" && driver != null)
        {
            var speedBoost = collider.GetComponent<SpeedBoost>();
            driver.moveSpeed = Mathf.Clamp(driver.moveSpeed + speedBoost.GetSpeedBonus(), 1, 50);
        }
    }
}
