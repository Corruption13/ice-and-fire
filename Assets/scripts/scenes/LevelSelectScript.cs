using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelSelectScript : MonoBehaviour
{
    public Button[] levelTiles;

    private void Start()
    {
 
        int progression = PlayerPrefs.GetInt("level_progress");
        Debug.Log("Progression");
        Debug.Log(progression);
        ProgressionLock(progression);
        BindOnClickFunctionToLevelTile(progression);
        AssignLevelScoreToTiles(progression);


    }

    void ProgressionLock(int progression)
    {

        for (int i = progression+1; i < levelTiles.Length; i++)
        {
            levelTiles[i].interactable = false;
        }
    }

    void AssignLevelScoreToTiles(int progression)
    {
        for(int i = 0; i < levelTiles.Length; i++)
        {
            TMP_Text[] childScripts = levelTiles[i].GetComponentsInChildren<TMP_Text>();
            float grade_time = PlayerPrefs.GetFloat("Ltime" + i.ToString());
            string grade = PlayerPrefs.GetString("Lgrade" + i.ToString());
            string best_time_grade = PlayerPrefs.GetString("LgradeAny" + i.ToString());
            float best_time = PlayerPrefs.GetFloat("LtimeAny" + i.ToString());

            childScripts[0].text = (i+1).ToString();                                     // Title
            childScripts[1].text = grade_time == 0? "": (grade_time).ToString("0.00s") ;        // Time
            childScripts[2].text = grade;                                            // Grade
            childScripts[3].text = best_time == 0 ? "" : (best_time).ToString("0.00s");
            childScripts[4].text = best_time_grade;
        }

    }

    void BindOnClickFunctionToLevelTile(int progression)
    {
        for (int i = 0; i < levelTiles.Length; i++)
        {
            int x = i; // Delegates are weird. Stackoverflow fix. 
            //levelTiles[i].onClick.AddListener(delegate { OnLevelTileClick(x); });
            Debug.Log("Binding " + i.ToString());
            levelTiles[i].onClick.AddListener(() => { OnLevelTileClick(x); });
        }
    }
    void OnLevelTileClick(int index)
    {
        Debug.Log("Loading" + index.ToString());
        LoadNextLevel(index.ToString());
    }


    public void LoadNextLevel(string scene_name)
    {
        string next_scene = (scene_name);
        if (Application.CanStreamedLevelBeLoaded(next_scene))
        {
            SceneManager.LoadScene(next_scene);
        }
        else
        {
            Debug.Log("Invalid Scene: " + scene_name);
            SceneManager.LoadScene("end");
        }


    }

}



    