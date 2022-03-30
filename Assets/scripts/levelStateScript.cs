using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelStateScript : MonoBehaviour
{
    public float victory_delay = 2;
    public float death_delay = 0.5f;
    public bool fireHasCompletedLevel = false;
    public bool waterHasCompletedLevel = false; 
    public bool bothAlive = true;

    public int fireGemsTotal;
    public int waterGemsTotal;

    private int fireGemsCollected = 0;
    private int waterGemsCollected = 0;

    void Update()
    {
        EndGameCheck();
    }

    void EndGameCheck()
    {
        if(!bothAlive)
            StartCoroutine( DeathSteps() );

        if (fireHasCompletedLevel && waterHasCompletedLevel)
            StartCoroutine( EndGameSteps() );
        
    }

    IEnumerator EndGameSteps() {

        PlayerPrefs.SetInt("score1", fireGemsCollected);
        PlayerPrefs.SetInt("total1", fireGemsTotal);
        PlayerPrefs.SetInt("score2", waterGemsCollected);
        PlayerPrefs.SetInt("total2", waterGemsTotal);
        PlayerPrefs.SetString("completed_level", SceneManager.GetActiveScene().name); 

        yield return new WaitForSeconds(victory_delay);
        Debug.Log("ByeBye");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator DeathSteps()
    {

        PlayerPrefs.SetInt("score1", fireGemsCollected);
        PlayerPrefs.SetInt("total1", fireGemsTotal);
        PlayerPrefs.SetInt("score2", waterGemsCollected);
        PlayerPrefs.SetInt("total2", waterGemsTotal);
        PlayerPrefs.SetString("completed_level", SceneManager.GetActiveScene().name);

        yield return new WaitForSeconds(death_delay);
        Debug.Log("Prepare to Die.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void SetFinalScore()
    {
        PlayerPrefs.SetInt("score1", fireGemsCollected);
        PlayerPrefs.SetInt("total1", fireGemsTotal);
        PlayerPrefs.SetInt("score2", waterGemsCollected);
        PlayerPrefs.SetInt("total2", waterGemsTotal);
        PlayerPrefs.SetString("completed_level", SceneManager.GetActiveScene().name);
    }
}
