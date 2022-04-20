using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathScript : MonoBehaviour
{
    //public LayerMask trapLayer;
    public string trap1tag;
    public string trap2tag = "AcidPit";
    private levelStateScript levelstate;

    void Start()
    {
        levelstate = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<levelStateScript>() ;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == trap1tag || col.gameObject.tag == trap2tag)
        {
            gameObject.SetActive(false);
            levelstate.PlayerKilled();
        }
    }
}
