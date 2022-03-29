using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathScript : MonoBehaviour
{
    public LayerMask trapLayer;
    public float hitboxSize = 0.35f;
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, hitboxSize, trapLayer))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
