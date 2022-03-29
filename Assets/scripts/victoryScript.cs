using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class victoryScript : MonoBehaviour
{

    public Transform groundCheck;
    public LayerMask finishLayer;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.35f, finishLayer))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); ;
    }
}
