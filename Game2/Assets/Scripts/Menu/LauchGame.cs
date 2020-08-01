using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LauchGame : MonoBehaviour
{
    public void LaunchIntroOne()
    {
        SceneManager.LoadScene("Intro1_map1");
    }

    public void Start()
    {
        if (GameObject.Find("Canvas") != null)
        {
            Destroy(GameObject.Find("Canvas"));
        }
        if (GameObject.Find("GameManager") != null)
        {
            Destroy(GameObject.Find("GameManager"));
        }
    }
}
