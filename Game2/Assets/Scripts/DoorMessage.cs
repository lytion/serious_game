using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMessage : MonoBehaviour
{
    public GameObject container;

    public void DisplayMessage()
    {
        Time.timeScale = 0;
        container.SetActive(true);
    }
    public void HideDoorMessage()
    {
        Time.timeScale = 1;
        container.SetActive(false);
    }
}
