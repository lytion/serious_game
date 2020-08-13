using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMessage : MonoBehaviour
{
    public GameObject doorContainer;
    public GameObject potionContainer;

    public void DisplayDoorMessage()
    {
        Time.timeScale = 0;
        doorContainer.SetActive(true);
    }
    public void HideDoorMessage()
    {
        Time.timeScale = 1;
        doorContainer.SetActive(false);
    }
    
    public void DisplayPotionMessage()
    {
        Time.timeScale = 0;
        potionContainer.SetActive(true);
    }
    public void HidePotionMessage()
    {
        Time.timeScale = 1;
        potionContainer.SetActive(false);
    }
}
