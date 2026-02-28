using UnityEngine;
using System.Collections;

public class AISpawner : MonoBehaviour
{
    public GameObject aiPrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    private bool hasSpawned = false;

    void Start()
    {
        StartCoroutine(SpawnRandomTime());
    }

    IEnumerator SpawnRandomTime()
    {
        float randomTime = Random.Range(10f, 20f);
        yield return new WaitForSeconds(randomTime);

        if (!hasSpawned)
        {
            SpawnAI();
            hasSpawned = true;
        }
    }

    void SpawnAI()
    {
        bool spawnLeft = Random.value > 0.5f;

        if (spawnLeft)
        {
            GameObject ai = Instantiate(aiPrefab, leftSpawnPoint.position, Quaternion.identity);
            ai.GetComponent<RunnerAI>().MoveDirection(Vector3.right);
        }
        else
        {
            GameObject ai = Instantiate(aiPrefab, rightSpawnPoint.position, Quaternion.identity);
            ai.GetComponent<RunnerAI>().MoveDirection(Vector3.left);
        }
        Debug.Log("AI Spawned at " + (spawnLeft ? "Left" : "Right") + " side.");
    }
}