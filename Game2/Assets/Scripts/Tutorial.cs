using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialContainer;
    public GameObject controlContainer;
    public GameObject questionContainer;
    public GameObject chestContainer;
    
    public void HideControl()
    {
        controlContainer.SetActive(false);
        questionContainer.SetActive(true);
        tutorialContainer.SetActive(false);
        Time.timeScale = 1;
    }

    public void DisplayTutorialQuestion()
    {
        questionContainer.SetActive(true);
        tutorialContainer.SetActive(true);
        Time.timeScale = 0;
    }
    public void HideQuestion()
    {
        questionContainer.SetActive(false);
        chestContainer.SetActive(true);
        tutorialContainer.SetActive(false);
    }

    public void DisplayTutorialChest()
    {
        chestContainer.SetActive(true);
        tutorialContainer.SetActive(true);
        Time.timeScale = 0;
    }
    public void HideChest()
    {
        chestContainer.SetActive(false);
        tutorialContainer.SetActive(false);
    }
    
    void Start()
    {
        questionContainer.SetActive(false);
        chestContainer.SetActive(false);
    }
}
