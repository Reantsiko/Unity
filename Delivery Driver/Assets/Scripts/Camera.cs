using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraHeight = -10;
    Transform playerTransform;
    // Start is called before the first frame update
    private void Start()
    {
        var player = FindObjectOfType<Driver>();
        playerTransform = player.gameObject.transform;
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraHeight);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (playerTransform == null)
        {
            Debug.LogError($"playerTransform is null on Camera!");
            return;
        }
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraHeight);
    }
}
