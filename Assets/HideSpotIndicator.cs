using UnityEngine;

public class HideSpotIndicator : MonoBehaviour
{
    public float detectDistance = 1.5f;
    public GameObject indicatorUI; // ข้อความ / icon

    private Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerController2D>().transform;

        if (indicatorUI != null)
            indicatorUI.SetActive(false);
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectDistance)
        {
            if (indicatorUI != null && !indicatorUI.activeSelf)
                indicatorUI.SetActive(true);
        }
        else
        {
            if (indicatorUI != null && indicatorUI.activeSelf)
                indicatorUI.SetActive(false);
        }
    }
}