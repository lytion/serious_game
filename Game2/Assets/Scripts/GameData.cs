using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int _playerHealth = 15;
    private static int _playerMaxHealth = 15;
    public HealthBar healthBar;
    public GameObject dmgText;
    public GameObject keyText;
    
    public int GetPlayerHealth()
    {
        return _playerHealth;
    }
    public int GetPlayerMaxHealth()
    {
        return _playerMaxHealth;
    }
    public void IncreasePlayerHealth(int hp)
    {
        _playerHealth += hp;
        healthBar.SetHealth(_playerHealth);
    }
    public void DecreasePlayerHealth(int hp)
    {
        _playerHealth -= hp;
        healthBar.SetHealth(_playerHealth);
    }
    
    private static int _playerAtk = 5;

    public int GetPlayerAtk()
    {
        return _playerAtk;
    }

    public void IncreasePlayerAtk(int dmg)
    {
        _playerAtk += dmg;
        dmgText.GetComponent<TextMeshProUGUI>().text = _playerAtk.ToString();
    }
    
    public void SetPlayerAtk(int atk)
    {
        _playerAtk = atk;
        dmgText.GetComponent<TextMeshProUGUI>().text = _playerAtk.ToString();
    }

    public void SetPlayerHealth(int hp)
    {
        _playerHealth = hp;
        healthBar.SetHealth(_playerHealth);
    }
    
    private static string _introToNextScene;

    public string GetIntroToNextScene()
    {
        return _introToNextScene;
    }

    public void SetIntroToNextScene(string scene)
    {
        _introToNextScene = scene;
    }
    
    private static bool _isTutorial;

    public bool GetIsTutorial()
    {
        return _isTutorial;
    }

    public void SetIsTutorial(bool tuto)
    {
        _isTutorial = tuto;
    }

    public void UpdateKeyFound()
    {
        keyText.GetComponent<TextMeshProUGUI>().text = GetComponent<DropSystem>().keyFound ? "1" : "0";
    }

    public void Start()
    {
        if (healthBar)
            healthBar.SetMaxHealth(_playerMaxHealth);
        if (dmgText)
            dmgText.GetComponent<TextMeshProUGUI>().text = GetPlayerAtk().ToString();
        if (keyText)
            keyText.GetComponent<TextMeshProUGUI>().text = GetComponent<DropSystem>().keyFound ? "1" : "0";
        SetIsTutorial(true);
        Time.timeScale = 0;
    }
}
