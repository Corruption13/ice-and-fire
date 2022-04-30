using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
public class levelStateScript : MonoBehaviour
{
    readonly string[] gradeChart = { "O", "A+", "A", "B+", "B", "C+", "C", "D", "F" };

    [Header("Players")]
    public GameObject firePlayer;
    public GameObject iceplayer;

    [Header("UI Elements")]
    public TMP_Text score;
    public TMP_Text timer;
    public TMP_Text levelInfo;

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



    void Update()
    {
        if (!bothAlive)
            StartCoroutine(DeathSteps());

        if (fireHasCompletedLevel && iceHasCompletedLevel)
            WinGame();
    }


    void WinGame()
    {
        SetFinalScore();
        sfxAudioSource.PlayAudio(13, false);
        Debug.Log("You Win!");
        StartCoroutine(WinGameSteps());
    }

    IEnumerator WinGameSteps() {
        yield return new WaitForSeconds(victory_delay);
        SceneManager.LoadScene("level_completed");
    }

    public void PlayerKilled()
    {
        bothAlive = false;
        sfxAudioSource.PlayAudio(12);

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
        string currentLevel = SceneManager.GetActiveScene().name;
        float time_taken = time_passed - victory_delay;

        string grade = CalculateGrade(time_taken); 
        PlayerPrefs.SetInt("score1", fireGemsCollected);
        PlayerPrefs.SetInt("total1", fireGemsTotal);
        PlayerPrefs.SetInt("score2", iceGemsCollected);
        PlayerPrefs.SetInt("total2", iceGemsTotal);
        PlayerPrefs.SetInt("score3", acidGemsCollected);
        PlayerPrefs.SetInt("total3", acidGemsTotal);
        PlayerPrefs.SetString("completed_level", currentLevel);
        PlayerPrefs.SetFloat("time_passed", time_taken);
        PlayerPrefs.SetString("grade", grade);

        // Save to player prefs:

        
        int progress = PlayerPrefs.GetInt("level_progress");
        if (progress <= int.Parse(currentLevel))
        {
            PlayerPrefs.SetInt("level_progress", int.Parse(currentLevel) + 1);
        }

        if (PlayerPrefs.GetString("Lgrade" + currentLevel) == "" || Array.FindIndex(gradeChart, x => x.Contains(grade))
                            < Array.FindIndex(gradeChart,  x => x.Contains(PlayerPrefs.GetString("Lgrade" + currentLevel))))
        {
            PlayerPrefs.SetString("Lgrade" + currentLevel.ToString(), grade); 
        }
        if(PlayerPrefs.GetFloat("Ltime" + currentLevel) == 0f || PlayerPrefs.GetFloat("Ltime"+ currentLevel) > time_taken)
        {
            PlayerPrefs.SetFloat("Ltime" + currentLevel, time_taken);
            PlayerPrefs.SetInt("NewBestTime", 1); 
        }
        PlayerPrefs.Save();
    }





    string CalculateGrade(float time_taken)
    {
        
        float score = 0;
        score += 2*fireGemsCollected / fireGemsTotal + 2*iceGemsCollected/iceGemsTotal + 2*acidGemsCollected/ acidGemsTotal;

        if (time_taken < best_time_for_level) score += 2;
        else if (time_taken < average_time_for_level) score += 1;

        if(score >= 0 && score <=8 )
            return gradeChart[8 - (int)score];
        return "G"; 
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
        sfxAudioSource.PlayAudio(1);
    }

    public void CollectSpecialGem()
    {
        acidGemsCollected++;
        UpdateScoreUI();
        sfxAudioSource.PlayAudio(0);
    }

    void UpdateScoreUI()
    {
        score.text = fireGemsCollected.ToString() + "     " 
                    + iceGemsCollected.ToString() + "     " 
                    + acidGemsCollected.ToString();
    }
    void UpdateTimerUI()
    {
        timer.text = time_passed.ToString("0.00");
    }

}
