using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int _playerHealth = 10;
    private static int _playerMaxHealth = 10;
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

    public void Start()
    {
        if (healthBar)
            healthBar.SetMaxHealth(_playerMaxHealth);
    }
}
