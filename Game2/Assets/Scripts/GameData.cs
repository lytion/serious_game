using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int _playerHealth = 10;
    public HealthBar healthBar;
    
    public int GetPlayerHealth()
    {
        return _playerHealth;
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
    
    public void Start()
    {
        healthBar.SetMaxHealth(_playerHealth);
    }
}
