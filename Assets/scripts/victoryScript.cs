using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class victoryScript : MonoBehaviour
{
    public bool isplayer1;
    public Transform groundCheck;
    public LayerMask finishLayer;
    public levelStateScript levelstate; 

    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.35f, finishLayer))
        {
            if(isplayer1)
                levelstate.waterHasCompletedLevel = true;
            else
                levelstate.fireHasCompletedLevel = true;
        }
    }
}
