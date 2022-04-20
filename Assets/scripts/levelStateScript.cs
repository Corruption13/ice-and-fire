using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class levelStateScript : MonoBehaviour
{

    [Header("Players")]
    public GameObject firePlayer;
    public GameObject iceplayer;

    [Header("UI Elements")]
    public Text score;
    public Text timer;
    public Text levelInfo;

    [Header("Level Gem Count ")]
    public int fireGemsTotal = 1;
    public int iceGemsTotal = 1;
    public int acidGemsTotal = 1;
    private int fireGemsCollected = 0;
    private int iceGemsCollected = 0;
    private int acidGemsCollected = 0;

    [Header("Level Time Limit")]
    public float best_time_for_level = 30f;
    public float average_time_for_level = 60f;
    private float time_passed = 0f;

    [Header("Time Delays")]
    public float victory_delay = 1f;
    public float death_delay = 0.5f;



    [Header("Game Status")]
    public bool fireHasCompletedLevel = false;
    public bool iceHasCompletedLevel = false; 
    public bool bothAlive = true;



    public playAudioScript sfxAudioSource;


    private void Start()
    {
        levelInfo.text = "Os Time: " + best_time_for_level + "s\nA+ Time: " + average_time_for_level + "s";
        PlayerPrefs.SetString("current_level", SceneManager.GetActiveScene().name);
    }

    private void LateUpdate()
    {
        time_passed += Time.deltaTime;
        UpdateTimerUI(); 


    }

    void UpdateTimerUI()
    {
        timer.text = time_passed.ToString("0.00");
    }

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
        sfxAudioSource.PlayAudio(13);
        Debug.Log("You Win!");
        yield return new WaitForSeconds(victory_delay);
        SceneManager.LoadScene("level_completed");
    }

    IEnumerator DeathSteps()
    {
        Time.timeScale = 0.7f;
        Debug.Log("You Died.");
        sfxAudioSource.PlayAudio(12);
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
        PlayerPrefs.SetFloat("time_passed", time_passed - victory_delay);
        PlayerPrefs.SetString("grade", CalculateGrade());
    }

    string CalculateGrade()
    {
        string[] grade = {"O", "A+", "A", "B+", "B", "C+", "C", "D", "F"};
        float score = 0;
        score += 2*fireGemsCollected / fireGemsTotal + 2*iceGemsCollected/iceGemsTotal + 2*acidGemsCollected/ acidGemsTotal;

        if (time_passed < best_time_for_level) score += 2;
        if (time_passed < average_time_for_level) score += 1;

        if(score >= 0 && score <=8 )
            return grade[8 - (int)score];
        return "Invalid Grade"; 
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
