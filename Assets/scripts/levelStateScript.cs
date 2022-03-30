using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class levelStateScript : MonoBehaviour
{

    public Text score; 

    public GameObject firePlayer;
    public GameObject iceplayer;
    public float victory_delay = 1f;
    public float death_delay = 0.5f;
    public bool fireHasCompletedLevel = false;
    public bool iceHasCompletedLevel = false; 
    public bool bothAlive = true;

    public int fireGemsTotal;
    public int iceGemsTotal;
    public int acidGemsTotal;

    private int fireGemsCollected = 0;
    private int iceGemsCollected = 0;
    private int acidGemsCollected = 0;



    void Update()
    {
        EndGameCheck();
    }

    void EndGameCheck()
    {
        if(!bothAlive)
            StartCoroutine( DeathSteps() );

        if (fireHasCompletedLevel && iceHasCompletedLevel)
            StartCoroutine( EndGameSteps() );
        
    }

    IEnumerator EndGameSteps() {


        SetFinalScore(); 
        yield return new WaitForSeconds(victory_delay);
        Debug.Log("You Win!");
        SceneManager.LoadScene("level_completed");
    }

    IEnumerator DeathSteps()
    {
        Time.timeScale = 0.7f;
        Debug.Log("You Died.");
        yield return new WaitForSeconds(death_delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void SetFinalScore()
    {
        PlayerPrefs.SetInt("score1", fireGemsCollected);
        PlayerPrefs.SetInt("total1", fireGemsTotal);
        PlayerPrefs.SetInt("score2", iceGemsCollected);
        PlayerPrefs.SetInt("total2", iceGemsTotal);
        PlayerPrefs.SetInt("score3", acidGemsCollected);
        PlayerPrefs.SetInt("total3", acidGemsTotal);
        PlayerPrefs.SetString("completed_level", SceneManager.GetActiveScene().name);
    }

    public void CollectGem(bool isIce)
    {
        if (isIce)
        {
            fireGemsCollected++; 
        }
        else
        {
            iceGemsCollected++;
        }
        UpdateScoreUI();
    }

    public void CollectSpecialGem()
    {
        acidGemsCollected++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        score.text = fireGemsCollected.ToString() + "     " 
                    + iceGemsCollected.ToString() + "     " 
                    + acidGemsCollected.ToString();
    }

}
