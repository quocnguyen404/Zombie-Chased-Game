using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPosition;
    private Vector3 tempPosition;

    private float minX = -60f;
    private float maxX = 60f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindWithTag("Player").transform;    
    }

    void LateUpdate()
    {
        tempPosition = transform.position;
        tempPosition.x = playerPosition.position.x;

        if (tempPosition.x < minX) tempPosition.x = minX;
        if (tempPosition.x > maxX) tempPosition.x = maxX;

        transform.position = tempPosition;
    }
}
