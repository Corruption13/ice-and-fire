using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform player1;
    public Transform player2;
    public float cameraYOffset = 2;
    public bool shouldFollowPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(shouldFollowPlayer)
        transform.position = new Vector3(player1.position.x, player1.position.y + cameraYOffset,
                                         transform.position.z); 

         

    }
}
