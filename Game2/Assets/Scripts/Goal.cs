using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class Goal : MonoBehaviour
{
    private AudioSource audioSrc;
    private InputQuestionUtilities _inputQuestionUtilities;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        _inputQuestionUtilities = GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSrc.Play();
        _inputQuestionUtilities.SetNextScene("boss");
        _inputQuestionUtilities.DisplayInputQuestionMenu();
        _inputQuestionUtilities.PrepareInputQuestion();
        // GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>().DisplayInputQuestionMenu();
        // GameObject.FindWithTag("GameManager").GetComponent<InputQuestionUtilities>().PrepareInputQuestion();
        // Destroy(other.gameObject);
        // GameManager.instance.RestartGame(2.5f);
        // SceneManager.LoadScene("boss");
    }
}
