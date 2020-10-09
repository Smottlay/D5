using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TransitionText : MonoBehaviour
{
    public GameObject MissionPanel;
    public Text MissionNameText;
    public TextMeshProUGUI MissionLoreText;
    public string[] missionName;

    [TextArea(15, 20)]
    public string[] missionLore;
    public float typingSpeed;

    Scene currentScene;
    public string sceneName;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == ("Main Scene Dawg"))
        {
            MissionNameText.text = missionName[0];
            StartCoroutine(TypeFirstLore());
        }
        else
        {
            MissionNameText.text = missionName[1];
            StartCoroutine(TypeSecondLore());
        }
    }
    
    IEnumerator TypeFirstLore()
    {
        foreach(char letter in missionLore[0].ToCharArray())
        {
            MissionLoreText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    IEnumerator TypeSecondLore()
    {
        foreach (char letter in missionLore[1].ToCharArray())
        {
            MissionLoreText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopAllCoroutines();
            gameObject.GetComponent<Transition>().EndTransition();
        }
    }
}
