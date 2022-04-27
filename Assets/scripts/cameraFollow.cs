using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Camera thisCam;
    public Transform player1;
    public Transform player2;
    public Transform anchor;

    public float cameraYOffset = 1f;
    public bool shouldFollowPlayer = true;

    private float total_points = 3;
    public float minOrthographicSize=5f;
    public float maxOrthographicSize=2f; 
    public float sensetivity=1f;

    private void Start()
    {
        if (!anchor)
        {
            GameObject temp = new();
            anchor = temp.transform;
            total_points = 2;
        }
    }

    void FixedUpdate()
    {
        if(shouldFollowPlayer)
        transform.position = new Vector3((player1.position.x + player2.position.x + anchor.position.x)/ total_points, 
                                         (player1.position.y + player2.position.y + anchor.position.y) / total_points + cameraYOffset,
                                         transform.position.z);
        thisCam.orthographicSize = minOrthographicSize + Mathf.Clamp((Vector2.Distance(player1.position, player2.position)) * sensetivity, 0f, maxOrthographicSize);
    }
}
