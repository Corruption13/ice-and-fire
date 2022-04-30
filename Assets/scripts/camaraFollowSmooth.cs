using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraFollowSmooth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Follow Parameters")]
    public float speed = .1f;
    public float cameraYOffset = 1f;
    public bool shouldFollowPlayer = true;

    private Camera thisCam;

    public Transform player1;
    public Transform player2;
    public Transform anchor;
    
    [Header("Zoom Settings")]
    public float minOrthographicSize = 5f;
    public float maxOrthographicSize = 2f;
    public float sensetivity = 1f;

    private float total_points = 3;
    private Vector3 lerpVector;
    private Vector3 target_pos;

    void Start()
    {
        thisCam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Vector3 target_pos = new Vector3((player1.position.x + player2.position.x + anchor.position.x) / total_points,
                                 (player1.position.y + player2.position.y + anchor.position.y) / total_points + cameraYOffset,
                                 transform.position.z);

        lerpVector = Vector3.Lerp(transform.position, target_pos, speed);

        transform.position = new Vector3(lerpVector.x, lerpVector.y, transform.position.z);
        thisCam.orthographicSize = minOrthographicSize + Mathf.Clamp((Vector2.Distance(player1.position, player2.position)) * sensetivity, 0f, maxOrthographicSize);
    }


}
