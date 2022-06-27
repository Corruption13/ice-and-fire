using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updraft : MonoBehaviour
{
    public bool isTurnedOnAtStart = true;
    public Vector2 force = new(0, 75);
    public float distanceMultiplyer = 1f;
    public GameObject airLifeBase;

    private bool isTurnedOn = true;
    private ParticleSystem ps;
    private AudioSource audiosource;
    float volume;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        audiosource = GetComponent<AudioSource>();
        volume = audiosource.volume;
        EnableAirLift(isTurnedOnAtStart);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isTurnedOn) return;
        float distance = Mathf.Exp(Vector2.Distance(airLifeBase.transform.position, collision.gameObject.transform.position) / distanceMultiplyer) + 0.0625f;
        collision.attachedRigidbody.AddForce(force / (distance) , ForceMode2D.Force);
    }

    public void EnableAirLift(bool turnOn)
    {
        isTurnedOn = turnOn;
        ps.enableEmission = turnOn;
        if(turnOn)
            audiosource.volume = volume;
        else
            audiosource.volume = 0;


    }


    public void ToggleAirLift()
    {
        EnableAirLift(!isTurnedOn);
    }

}
