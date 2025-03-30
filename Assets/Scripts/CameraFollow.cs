using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;    // Reference to Player 1
    public Transform player2;    // Reference to Player 2
    public float cameraDistance = 10f;  // Distance from the midpoint along the z-axis

    void LateUpdate()
    {
       
        Vector3 desiredPosition = (player1.position + player2.position) / 2 + new Vector3(0, 0, -cameraDistance);

        transform.position = desiredPosition;

        

        
    }
}
