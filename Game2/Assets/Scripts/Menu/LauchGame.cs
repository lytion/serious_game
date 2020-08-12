using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LauchGame : MonoBehaviour
{
    public void LaunchIntroOne()
    {
        if (GameObject.Find("GameManager"))
            GameObject.Find("GameManager").GetComponent<GameData>().ResetStats();
        CleanObject();
        GameObject.Find("GameManagerMenu").GetComponent<GameData>().SetIntroToNextScene("intro1_map");
        SceneManager.LoadScene("Game");
    }

    public void LaunchIntroTwo()
    {
        if (GameObject.Find("GameManager"))
            GameObject.Find("GameManager").GetComponent<GameData>().ResetStats();
        CleanObject();
        GameObject.Find("GameManagerMenu").GetComponent<GameData>().SetIntroToNextScene("intro2_map");
        SceneManager.LoadScene("Game");
    }

    public void CleanObject()
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
    public void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("GameManagerMenu"));
    }
}
