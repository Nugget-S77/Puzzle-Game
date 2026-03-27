using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");

        // โหลดฉากใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // หรือหยุดเกม
        // Time.timeScale = 0f;
    }
}