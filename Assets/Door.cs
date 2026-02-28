using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string doorID;
    public string requiredItemID;   // ถ้าเว้นว่าง = ไม่ต้องใช้ไอเทม
    public string sceneToLoad;
    public float openDistance = 1.5f;

    public bool isOpen;

    private Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerController2D>().transform;
    }

    void Update()
    {
        if (isOpen) return;

        float distance = Vector2.Distance(
            transform.position,
            player.position);

        if (distance > openDistance) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryOpen();
        }
    }

    void TryOpen()
    {
        // 🔥 กรณีไม่ต้องใช้ไอเทม
        if (string.IsNullOrEmpty(requiredItemID))
        {
            OpenDoor();
            return;
        }

        // 🔥 กรณีต้องใช้ไอเทม
        if (Inventory.instance.HasItem(requiredItemID))
        {
            Inventory.instance.RemoveItem();
            OpenDoor();
        }
        else
        {
            Debug.Log("ไม่มีไอเทมที่ต้องใช้");
        }
    }

    void OpenDoor()
    {
        isOpen = true;

        // 🔥 เซฟก่อนเปลี่ยนฉาก
        SaveManager.instance.SaveGame(
            SaveManager.instance.currentSlot);

        // 🔥 โหลดฉาก
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadState(bool opened)
    {
        isOpen = opened;
    }
}