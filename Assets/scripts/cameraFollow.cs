using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Camera thisCam;
    public Transform player1;
    public Transform player2;
    public float cameraYOffset = 2;
    public bool shouldFollowPlayer = true;

    public float minOrthographicSize=5f;
    public float maxOrthographicSize=10f; 
    public float sensetivity=1f;

    void LateUpdate()
    {
        if(shouldFollowPlayer)
        transform.position = new Vector3((player1.position.x + player2.position.x)/2, 
                                         (player1.position.y + player2.position.y) / 2 + cameraYOffset,
                                         transform.position.z);
        thisCam.orthographicSize = minOrthographicSize + Mathf.Clamp(Vector2.Distance(player1.position, player2.position) * sensetivity, 0f, maxOrthographicSize);
    }
}
