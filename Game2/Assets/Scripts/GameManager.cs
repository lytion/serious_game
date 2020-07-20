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
        if (audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }

        audioSrc.clip = shootClip;
        audioSrc.Play();
    }
}
