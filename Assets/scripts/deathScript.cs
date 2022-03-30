using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathScript : MonoBehaviour
{
    //public LayerMask trapLayer;
    public string trap1tag;
    public string trap2tag = "AcidPit";
    public levelStateScript levelstate;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == trap1tag || col.gameObject.tag == trap2tag)
        {
            Destroy(gameObject);
            levelstate.bothAlive = false;
        }
    }
}
