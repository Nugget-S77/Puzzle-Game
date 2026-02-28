using UnityEngine;

public class PlayTimeTracker : MonoBehaviour
{
    public static PlayTimeTracker instance;
    public float currentTime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;
    }
}