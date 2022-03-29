using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float cameraYOffset = 2;
    public bool shouldFollowPlayer = true;

    void LateUpdate()
    {
        if(shouldFollowPlayer)
        transform.position = new Vector3((player1.position.x + player2.position.x)/2, 
                                         (player1.position.y + player2.position.y) / 2 + cameraYOffset,
                                         transform.position.z); 
    }
}
