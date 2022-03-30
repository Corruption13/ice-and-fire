using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryScript : MonoBehaviour
{
    public bool isplayer1;
    public Transform groundCheck;
    public LayerMask finishLayer;
    public levelStateScript levelstate; 

    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.5f, finishLayer))
        {
            if(isplayer1)
                levelstate.iceHasCompletedLevel = true;
            else
                levelstate.fireHasCompletedLevel = true;
        }
    }
}
