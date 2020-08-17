using System;
using UnityEngine;
using System.Collections;
using Random = System.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class mobs : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameObject Player;
    private float Range;
    public int health;
    private QuestionUtilities _questionUtilities;

    public Transform[] moveSpot;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

    [SerializeField]
    private float speedMultiplier;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag ("Player");
        _questionUtilities = GameObject.FindWithTag("GameManager").GetComponent<QuestionUtilities>();
        waitTime = startWaitTime;
        if (moveSpot == null)
            return;
        randomSpot = new System.Random().Next(0, moveSpot.Length);
    }
    
    void Update()
    {
        Range = Vector2.Distance(transform.position, Player.transform.position);
        if (Range <= 4f) 
        { 
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speedMultiplier * Time.deltaTime);
        }
        else
        {
            if (moveSpot == null || moveSpot.Length == 0)
                return;
            transform.position =
                Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, speedMultiplier * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = new System.Random().Next(0, moveSpot.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collide");
            _questionUtilities.SetEnemyType(gameObject.name == "Boss" ? "boss" : "mob");
            _questionUtilities.SetEnemy(this, gameObject);
            _questionUtilities.StartBattle();
            // GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>().DisplayInputQuestionMenu();
            // GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>().PrepareInputQuestion();
            // Destroy(other.gameObject);   
        }
    }
}
