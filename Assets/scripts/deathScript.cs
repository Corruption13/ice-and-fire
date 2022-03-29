using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathScript : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask trapLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.35f, trapLayer))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); ;
    }
}
