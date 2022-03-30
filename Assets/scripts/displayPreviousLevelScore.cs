using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class displayPreviousLevelScore : MonoBehaviour
{
    public Text firegems;
    public Text icegems;
    public Text acidgems;
    public Text level_no;
 
    void Start()
    {
        firegems.text = PlayerPrefs.GetInt("score1").ToString() + "/" + PlayerPrefs.GetInt("total1").ToString();
        icegems.text = PlayerPrefs.GetInt("score2").ToString() + "/" + PlayerPrefs.GetInt("total2").ToString();
        acidgems.text = PlayerPrefs.GetInt("score3").ToString() + "/" + PlayerPrefs.GetInt("total3").ToString();
        level_no.text = "Completed Level " + PlayerPrefs.GetString("completed_level"); 
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
