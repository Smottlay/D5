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

    public float activeTimer;
    public bool activeBool;

    public float waitForSkip;
    public int clickCount;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == ("Level 1"))
        {
            MissionNameText.text = missionName[0];
            StartCoroutine(TypeFirstLore());
        }
        else if(sceneName ==  ("Level 2"))
        {
            MissionNameText.text = missionName[1];
            StartCoroutine(TypeSecondLore());
        }
        else
        {
            return;
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
        waitForSkip -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && waitForSkip <= 0 && clickCount ==0)
        {
            StopAllCoroutines();
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                MissionLoreText.text = missionLore[0];
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                MissionLoreText.text = missionLore[1];
            }
            clickCount += 1;
        }
        else if (Input.GetButtonDown("Fire1") && clickCount == 1)
        {
            gameObject.GetComponent<Transition>().EndTransition();
            activeTimer = 1f;
            activeBool = true;
        }

        activeTimer -= Time.deltaTime;

        if(activeTimer <= 0 && activeBool)
        {
            gameObject.GetComponent<Transition>().ActivateUI();
            gameObject.SetActive(false);
        }
    }
}
