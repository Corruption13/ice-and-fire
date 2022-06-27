using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class displayPreviousLevelScore : MonoBehaviour
{
    public TextMeshProUGUI firegems;
    public TextMeshProUGUI icegems;
    public TextMeshProUGUI acidgems;
    public TextMeshProUGUI level_no;
    public TextMeshProUGUI grade;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI best_time_alert;

    void Start()
    {
        icegems.text = PlayerPrefs.GetInt("score1").ToString() + "/" + PlayerPrefs.GetInt("total1").ToString();
        firegems.text = PlayerPrefs.GetInt("score2").ToString() + "/" + PlayerPrefs.GetInt("total2").ToString();
        acidgems.text = PlayerPrefs.GetInt("score3").ToString() + "/" + PlayerPrefs.GetInt("total3").ToString();
        level_no.text = "Completed Level " + PlayerPrefs.GetString("completed_level");
        grade.text = PlayerPrefs.GetString("grade");
        timer.text = PlayerPrefs.GetFloat("time_passed").ToString("0.00") + " s";

        if(PlayerPrefs.GetInt("NewBestTime") == 1)
            best_time_alert.text = "NEW PERSONAL BEST TIME!"; 
    }

    /*
    PlayerPrefs.SetInt("score1", fireGemsCollected);
        PlayerPrefs.SetInt("total1", fireGemsTotal);
        PlayerPrefs.SetInt("score2", iceGemsCollected);
        PlayerPrefs.SetInt("total2", iceGemsTotal);
        PlayerPrefs.SetInt("score3", acidGemsCollected);
        PlayerPrefs.SetInt("total3", acidGemsTotal);
        PlayerPrefs.SetString("completed_level", SceneManager.GetActiveScene().name);
    */

    // Update is called once per frame

}
