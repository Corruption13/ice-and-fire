using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adjustVolume : MonoBehaviour
{
    private void Start()
    {
        AudioListener.volume = Mathf.Clamp(1f - PlayerPrefs.GetFloat("avolumeListener" + gameObject.name), 0, 1);
    }
    public void SliderAudioAdjust(Slider s)
    {
        AudioListener.volume = s.value;
        PlayerPrefs.SetFloat("avolumeListener" + gameObject.name, 1f - s.value); // 0 if not defined. so make it 100 if muted.
    }
}
