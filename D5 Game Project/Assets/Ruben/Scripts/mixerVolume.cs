using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class mixerVolume : MonoBehaviour
{
    public Slider slider;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.GetFloat("volume", out float volume);
        slider.value = volume;
    }
}
