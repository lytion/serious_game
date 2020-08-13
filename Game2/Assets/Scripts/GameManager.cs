using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    private AudioSource audioSrc;

    [SerializeField]
    private AudioClip shootClip;

    public static GameManager instance;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        instance = this;
        // Dont destroy gameManager and Canvas to keep current health between levels
        // and the questionnaire
        DontDestroyOnLoad(transform.gameObject);
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(GameObject.Find("Items"));
    }

    public void ReloadGame()
    {
        Time.timeScale = 1;
        GameObject.Find("DeathContainer").SetActive(false);
        if (SceneManager.GetActiveScene().name != "Intro1_boss")
            GetComponent<GameData>().SetPlayerAtk(5); 
        int hp = GetComponent<GameData>().GetPlayerMaxHealth();
        GetComponent<GameData>().SetPlayerHealth(hp);
        GetComponent<DropSystem>().SetAllItemNonActive();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame(float delay)
    {
        StartCoroutine(RestartGameCoroutine(delay));
    }

    private IEnumerator RestartGameCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game");
    }

    public void PlayShootingSfx()
    {
        // if (audioSrc.isPlaying)
        // {
        //     audioSrc.Stop();
        // }

        audioSrc.clip = shootClip;
        audioSrc.Play();
    }
}
