using UnityEngine;

public class EnemyProximitySound : MonoBehaviour
{
    public float detectDistance = 8f; // 🔥 เพิ่มระยะตรงนี้
    public AudioSource audioSource;

    private Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerController2D>().transform;

        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        if (player == null || audioSource == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectDistance)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();

            // 🔊 ค่อย ๆ ดังขึ้นเมื่อเข้าใกล้
            float volume = 1 - (distance / detectDistance);
            audioSource.volume = Mathf.Clamp01(volume);
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }
}