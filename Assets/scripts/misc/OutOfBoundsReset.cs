using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsReset : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform destination;
    private void Start()
    {
        destination = transform.parent.GetChild(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = destination.position;
    }
}
