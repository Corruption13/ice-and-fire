using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    // Update is called once per frame
    public void PlayAudio(int index)
    {
        if(!checkIfAudioAlreadyPlaying())
            audioSource.PlayOneShot(getClipByIndex(index));
    }

    public bool checkIfAudioAlreadyPlaying()
    {
        return audioSource.isPlaying; 
    }
    private AudioClip getClipByIndex(int index)
    {
        return audioClipArray[index];
    }
}
