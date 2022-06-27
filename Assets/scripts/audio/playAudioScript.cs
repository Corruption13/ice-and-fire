using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playAudioScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    private void Start()
    {
        audioSource.volume = Mathf.Clamp( 100f - PlayerPrefs.GetFloat("avolume" + gameObject.name), 0, 100); 
    }

    // Update is called once per frame
    public void PlayAudio(int index, bool allowOverlapAudio = true)
    {
        if(allowOverlapAudio || !checkIfAudioAlreadyPlaying())
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

    public void SliderAudioAdjust(Slider s)
    {
        audioSource.volume = s.value;
        PlayerPrefs.SetFloat("avolume" + gameObject.name, 100 - s.value); // 0 if not defined. so make it 100 if muted.
    }
}
