using UnityEngine;
using System.Collections;

public class JumpScareInteract : MonoBehaviour
{
    public GameObject jumpImage;   // ภาพ jumpscare
    public float showTime = 1f;    // เวลาที่ภาพแสดง

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(JumpScare());
        }
    }

    IEnumerator JumpScare()
    {
        jumpImage.SetActive(true);

        yield return new WaitForSeconds(showTime);

        jumpImage.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}