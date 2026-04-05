using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerAI : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDir;
    public GameObject player;

    private SpriteRenderer sprite; 

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void MoveDirection(Vector3 dir)
    {
        moveDir = dir;
    }

    void Update()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);

        if (moveDir.x != 0) 
        {
            sprite.flipX = moveDir.x < 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<PlayerController2D>() != null || other.CompareTag("Player"))
        {
            Debug.Log("Hit Player! Loading Death Scene...");
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}