using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetScores : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
