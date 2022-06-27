using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGameWhenInput : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            GetComponent<levelStateScript>().StartGameTimer();
            Debug.Log("Start!");
            this.enabled = false;
        }
        
    }
}
