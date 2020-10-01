using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource[] music;

    // Start is called before the first frame update
    void Start()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        music = gameObject.GetComponentsInChildren<AudioSource>();
        if(currentScene == 1)
        {
            music[0].Play();
        }
        else if(currentScene == 2)
        {
            music[1].Play();
        }
    }

    public void OnDeath()
    {
        music[0].Stop();
        music[1].Stop();
        music[2].Play();
    }
}
