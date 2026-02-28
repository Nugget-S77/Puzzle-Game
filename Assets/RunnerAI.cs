using UnityEngine;

public class RunnerAI : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDir;
     public GameObject player;

    public void MoveDirection(Vector3 dir)
    {
        moveDir = dir;
    }

    void Update()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);
    }
void OnTriggerEnter2D(Collider2D other)
{
    if (other.GetComponentInParent<PlayerController2D>() != null)
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}
    void OnBecameInvisible()
{
    Destroy(gameObject);
}
}