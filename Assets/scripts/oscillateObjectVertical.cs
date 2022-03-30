using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillateObjectVertical : MonoBehaviour
{
    // Start is called before the first frame update
    public float frequency = 2f;
    public float amplitude = 0.1f;
    private float y_init;
    private void Start()
    {
        y_init = transform.position.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float yPos = Mathf.Sin(Time.time * frequency) * amplitude + y_init;
        transform.position = new Vector2(this.transform.position.x, yPos); 
    }
}
