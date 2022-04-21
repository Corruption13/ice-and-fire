using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryScript : MonoBehaviour
{
    public bool isplayer1;
    public Transform groundCheck;
    public string TrophyTag; 
    private levelStateScript levelstate;

    void Start()
    {
        levelstate = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<levelStateScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag(TrophyTag))
        {
            Destroy(col.gameObject);
            if (isplayer1)
                levelstate.iceHasCompletedLevel = true;
            else
                levelstate.fireHasCompletedLevel = true;
        }
    }

}
