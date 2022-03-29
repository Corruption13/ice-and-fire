using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelStateScript : MonoBehaviour
{
    public bool fireHasCompletedLevel = false;
    public bool waterHasCompletedLevel = false; 
    public bool bothAlive = true;

    public int fireGemsTotal;
    public int waterGemsTotal;

    

    private int fireGemsCollected = 0;
    private int waterGemsCollected = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EndGameCheck();
    }

    void EndGameCheck()
    {
        if(!bothAlive)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (fireHasCompletedLevel && waterHasCompletedLevel)
        {
            Debug.LogError("Victory!"); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
