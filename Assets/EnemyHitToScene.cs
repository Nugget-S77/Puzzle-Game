using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitToScene : MonoBehaviour
{
    [SerializeField] private string sceneName = "GameOver";
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            SceneManager.LoadScene(sceneName);
        }
    }
}