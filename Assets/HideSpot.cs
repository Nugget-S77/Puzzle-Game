using UnityEngine;

public class HideSpot : MonoBehaviour
{
    public float hideDistance = 1.5f;

    private PlayerController2D controller;
    private SpriteRenderer sprite;
    private Collider2D col;

    private bool isHidden = false;

    void Start()
    {
        GameObject player = FindObjectOfType<PlayerController2D>().gameObject;

        controller = player.GetComponent<PlayerController2D>();
        sprite = player.GetComponent<SpriteRenderer>();
        col = player.GetComponent<Collider2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(
            transform.position,
            controller.transform.position);

        if (distance > hideDistance) return;

        if (!isHidden && Input.GetKeyDown(KeyCode.E))
        {
            HidePlayer();
        }
        else if (isHidden && Input.GetKeyDown(KeyCode.E))
        {
            UnhidePlayer();
        }
    }

    void HidePlayer()
    {
        isHidden = true;

        controller.SetMovement(false);
        sprite.enabled = false;
        col.enabled = false;

        // 🔥 เซฟทันทีเมื่อซ่อน
        if (SaveManager.instance != null)
            SaveManager.instance.SaveGame(SaveManager.instance.currentSlot);
    }

    void UnhidePlayer()
    {
        isHidden = false;

        controller.SetMovement(true);
        sprite.enabled = true;
        col.enabled = true;

        // 🔥 เซฟทันทีเมื่อออกจากที่ซ่อน
        if (SaveManager.instance != null)
            SaveManager.instance.SaveGame(SaveManager.instance.currentSlot);
    }

    // 🔥 ใช้กับ SaveManager
    public bool IsHidden()
    {
        return isHidden;
    }

    public void ForceHide()
    {
        if (!isHidden)
        {
            isHidden = true;
            controller.SetMovement(false);
            sprite.enabled = false;
            col.enabled = false;
        }
    }

    public void ForceUnhide()
    {
        if (isHidden)
        {
            isHidden = false;
            controller.SetMovement(true);
            sprite.enabled = true;
            col.enabled = true;
        }
    }
}