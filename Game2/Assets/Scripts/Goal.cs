using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class Goal : MonoBehaviour
{
    private AudioSource audioSrc;
    private QuestionUtilities _questionUtilities;
    public string nextScene;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        _questionUtilities = GameObject.FindWithTag("GameManager").GetComponent<QuestionUtilities>();
        if (GameObject.Find("GameManagerMenu"))
        {
            nextScene = GameObject.Find("GameManagerMenu").GetComponent<GameData>().GetIntroToNextScene();
            Destroy(GameObject.Find("GameManagerMenu"));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameObject.Find("GameManager").GetComponent<DropSystem>().keyFound)
        {
            GameObject.Find("GameManager").GetComponent<DoorMessage>().DisplayMessage();
        }
        else
        {
            audioSrc.Play();
            _questionUtilities.SetEnemyType("door");
            _questionUtilities.SetNextScene(nextScene);
            _questionUtilities.StartBattle();            
        }
    }
}
