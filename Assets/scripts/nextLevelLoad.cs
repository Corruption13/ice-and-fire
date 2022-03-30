using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelLoad : MonoBehaviour
{
    private string previous_level;
    // Start is called before the first frame update
    private void Start()
    {   
        previous_level = 
        PlayerPrefs.GetString("completed_level");
        
    }
 
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(previous_level);
    }
}
