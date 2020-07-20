using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Hazard : MonoBehaviour
{
    public GameObject bloodSprayPrefab;
    public Sprite hitSprite;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        GameManager.instance.PlayShootingSfx();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            spriteRenderer.sprite = hitSprite;
            GameManager.instance.RestartGame(3f);
            StartCoroutine(SprayBlood(3f, coll.contacts[0].point, coll.gameObject));
        }
        else
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject, 0.1f);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator SprayBlood(float delay, Vector2 position, GameObject player)
    {
        var bloodSpray = (GameObject)Instantiate(bloodSprayPrefab, position, Quaternion.identity);
        Destroy(bloodSpray, 3f);
        Destroy(player);
        yield return new WaitForSeconds(delay);
    }
}