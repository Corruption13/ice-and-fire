using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public string enemyTag= "Player";

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == enemyTag)
        {
            Destroy(gameObject);
        }
    }
}
