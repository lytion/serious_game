using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type;
    public bool itemDrop = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject manager = GameObject.Find("GameManager");
        if (other.tag == "Player")
        {
            if (type == "weapon")
            {
                Debug.Log(">>> Player atk increase !");
                manager.GetComponent<GameData>().IncreasePlayerAtk(3);
                gameObject.SetActive(false);
            }
            else if (type == "potion")
            {
                if (manager.GetComponent<GameData>().GetPlayerHealth() < manager.GetComponent<GameData>().GetPlayerMaxHealth())
                {
                    Debug.Log(">>> Player health increase !");
                    manager.GetComponent<GameData>().IncreasePlayerHealth(3);
                    gameObject.SetActive(false);
                }
                else
                {
                    manager.GetComponent<InfoMessage>().DisplayPotionMessage();
                }
            }
            else if (type == "key")
            {
                GameObject.Find("GameManager").GetComponent<DropSystem>().SetKeyFound(true);
                GameObject.Find("GameManager").GetComponent<GameData>().UpdateKeyFound();
                gameObject.SetActive(false);
            }
        }
    }
}
