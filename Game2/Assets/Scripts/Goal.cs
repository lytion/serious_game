using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class Goal : MonoBehaviour
{
    private AudioSource audioSrc;
    private QuestionUtilities _questionUtilities;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        _questionUtilities = GameObject.FindWithTag("GameManager").GetComponent<QuestionUtilities>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSrc.Play();
        _questionUtilities.SetEnemyType("door");
        _questionUtilities.SetNextScene("boss");
        _questionUtilities.StartBattle();
    }
}
