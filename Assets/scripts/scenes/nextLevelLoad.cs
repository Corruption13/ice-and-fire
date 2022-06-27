using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelLoad : MonoBehaviour
{
    public string end_screen_scene = "end"; 
    private string previous_level;
    
    // Start is called before the first frame update
    private void Start()
    {   
        previous_level = PlayerPrefs.GetString("completed_level");
        
    }
 
    public void LoadNextLevel()
    {
        string next_scene = (int.Parse(previous_level) + 1).ToString();
        if (Application.CanStreamedLevelBeLoaded(next_scene)) 
        {
            SceneManager.LoadScene(next_scene);
        }
        else
        {
            SceneManager.LoadScene(end_screen_scene); 
        }

        
    }
}
