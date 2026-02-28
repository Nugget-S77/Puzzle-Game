using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image itemImage;

    public Sprite keySprite;

    void Awake()
    {
        instance = this;
        itemImage.enabled = false;
    }

    public void ShowItem(string itemID)
    {
        if (itemID == "Key")
            itemImage.sprite = keySprite;

        itemImage.enabled = true;
    }

    public void HideItem()
    {
        itemImage.enabled = false;
    }
}