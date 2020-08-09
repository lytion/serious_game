using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LauchGame : MonoBehaviour
{
    public void LaunchIntroOne()
    {
        GameObject.Find("GameManagerMenu").GetComponent<GameData>().SetIntroToNextScene("intro1_map");
        SceneManager.LoadScene("Game");
    }

    public void LaunchIntroTwo()
    {
        GameObject.Find("GameManagerMenu").GetComponent<GameData>().SetIntroToNextScene("intro2_map");
        SceneManager.LoadScene("Game");
    }

    public void Start()
    {
        DontDestroyOnLoad(GameObject.Find("GameManagerMenu"));
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
