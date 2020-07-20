using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class mobs : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameObject Player;
    private float Range;

    [SerializeField]
    private float speedMultiplier;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag ("Player");
    }
    
    void Update()
    { 
        Range = Vector2.Distance(transform.position, Player.transform.position);
        if (Range <= 10f)
         {
             transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speedMultiplier * Time.deltaTime);
         }
    }
}
