using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectGemScript : MonoBehaviour
{

    public string gem1Tag;
    public string gem2Tag = "AcidGem";
    public levelStateScript levelstate;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == gem1Tag)
        {
            Destroy(col.gameObject); 
            levelstate.CollectGem(this.gameObject.tag == "IcePlayer");
            // if argument true, increments ice score, else fire score.
        }
        else if(col.gameObject.tag == gem2Tag)
        {
            Destroy(col.gameObject);
            levelstate.CollectSpecialGem(); 
        }
    }
}
