using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int _playerHealth = 15;
    private static int _playerMaxHealth = 15;
    public HealthBar healthBar;
    
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
        if (_playerHealth - hp <= 0)
            GameManager.instance.RestartGame(2.5f);
        else
        {
            _playerHealth -= hp;
            healthBar.SetHealth(_playerHealth);   
        }
    }
    
    private static int _playerAtk = 5;

    public int GetPlayerAtk()
    {
        return _playerAtk;
    }

    public void IncreasePlayerAtk(int dmg)
    {
        _playerAtk += dmg;
    }
    
    public void SetPlayerAtk(int atk)
    {
        _playerAtk = atk;
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

    public void Start()
    {
        if (healthBar)
            healthBar.SetMaxHealth(_playerMaxHealth);
        SetIsTutorial(true);
    }
}
