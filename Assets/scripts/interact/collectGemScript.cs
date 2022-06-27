using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectGemScript : MonoBehaviour
{

    public string gem1Tag;
    public string gem2Tag = "AcidGem";

    private levelStateScript levelstate;
    void Start()
    {
       
            levelstate = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<levelStateScript>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == gem1Tag)
        {
            Destroy(col.gameObject); 
            levelstate.CollectGem(gameObject.CompareTag("IcePlayer"));
           
            // if argument true, increments ice score, else fire score.
        }
        else if(col.gameObject.CompareTag(gem2Tag))
        {
            Destroy(col.gameObject);
            levelstate.CollectSpecialGem();
            
        }
    }
}
