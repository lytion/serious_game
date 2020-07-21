using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>().DisplayInputQuestionMenu();
            GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>().PrepareInputQuestion();
            Destroy(other.gameObject);   
        }
    }
}
