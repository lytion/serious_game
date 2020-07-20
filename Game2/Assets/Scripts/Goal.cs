using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class Goal : MonoBehaviour
{
    private AudioSource audioSrc;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSrc.Play();
        Destroy(other.gameObject);
        GameManager.instance.RestartGame(2.5f);
        GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>().DisplayInputQuestionMenu();
        GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>().PrepareInputQuestion();
    }
}
