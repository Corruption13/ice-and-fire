using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryScript : MonoBehaviour
{
    public bool isplayer1;
    public Transform groundCheck;
    public LayerMask finishLayer;
    private levelStateScript levelstate;

    void Start()
    {
        levelstate = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<levelStateScript>();
    }

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
