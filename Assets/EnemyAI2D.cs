using UnityEngine;

public class EnemyAI2D : MonoBehaviour
{
    public float speed = 2f;
    private bool canWalk = false;

    void Update()
    {
        if (canWalk)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canWalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canWalk = false;
        }
    }
}