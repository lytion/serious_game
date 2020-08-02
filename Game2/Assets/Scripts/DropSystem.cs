using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropSystem : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> weapon;
    [SerializeField]
    public List<GameObject> potion;
    public string key = "key";
    public bool keyFound = false;

    public void DropItem(int chestRemaining)
    {
        if (chestRemaining == 1 && !keyFound)
        {
            Debug.Log(">>> Loot Key !");
            keyFound = true;
            return;
        }

        int idx = new System.Random().Next(0, keyFound ? 80 : 100);
        if (idx >= 0 && idx < 30)
        {
            Debug.Log(">>> Random Loot Potion !");
            int index = GetRandomPotion();
            potion[index].transform.position = new Vector3(GetPlayerPosition().x + 2, GetPlayerPosition().y, 0);
            potion[index].SetActive(true);
        }
        else if (idx >= 30 && idx < 80)
        {
            Debug.Log(">>> Random Loot Weapon !");
            int index = GetRandomWeapon();
            weapon[index].transform.position = new Vector3(GetPlayerPosition().x + 2, GetPlayerPosition().y, 0);
            weapon[index].SetActive(true);
        }
        else
        {
            Debug.Log(">>> Random Loot Key !");
            keyFound = true;
        }
    }

    public int GetRandomWeapon()
    {
        for (int i = 0; i < weapon.Count; i++)
        {
            int idx = new System.Random().Next(0, weapon.Count);
            if (!weapon[idx].GetComponent<Item>().itemDrop)
                return idx;
        }
        return 0;
    }
    
    public int GetRandomPotion()
    {
        for (int i = 0; i < weapon.Count; i++)
        {
            int idx = new System.Random().Next(0, potion.Count);
            if (!potion[idx].GetComponent<Item>().itemDrop)
                return idx;
        }
        return 0;
    }

    public int GetAllChests()
    {
        Debug.Log(">>> Found "+GameObject.FindGameObjectsWithTag("chest").Length+" chests in the map.");
        return GameObject.FindGameObjectsWithTag("chest").Length;
    }
    
    public Vector2 GetPlayerPosition()
    {
        return GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
