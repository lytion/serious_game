using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class mobs : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameObject Player;
    private float Range;
    public int health = 10;
    private QuestionUtilities _questionUtilities;

    [SerializeField]
    private float speedMultiplier;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag ("Player");
        _questionUtilities = GameObject.FindWithTag("GameManager").GetComponent<QuestionUtilities>();
    }
    
    void Update()
    {
        Range = Vector2.Distance(transform.position, Player.transform.position);
        if (Range <= 4f)
         {
             transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speedMultiplier * Time.deltaTime);
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
