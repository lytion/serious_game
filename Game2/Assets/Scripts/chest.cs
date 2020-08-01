using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    private QuestionUtilities _questionUtilities;
    public int health;

    private void Awake()
    {
        _questionUtilities = GameObject.FindWithTag("GameManager").GetComponent<QuestionUtilities>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _questionUtilities.SetEnemyType("chest");
            _questionUtilities.SetChest(this, gameObject);
            _questionUtilities.StartBattle();
        }
    }
}
