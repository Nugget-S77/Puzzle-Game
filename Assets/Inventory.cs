using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public string currentItem = "";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddItem(string itemID)
    {
        currentItem = itemID;
        Debug.Log("เก็บไอเท็ม: " + itemID);

        UIManager.instance.ShowItem(itemID);

        SaveManager.instance.SaveGame(SaveManager.instance.currentSlot);
    }

    public bool HasItem(string itemID)
    {
        return currentItem == itemID;
    }

    public void RemoveItem()
    {
        currentItem = "";
        UIManager.instance.HideItem();

        SaveManager.instance.SaveGame(SaveManager.instance.currentSlot);
    }

    // 🔥 ใช้กับ Save System
    public List<string> GetItemList()
    {
        List<string> list = new List<string>();

        if (!string.IsNullOrEmpty(currentItem))
            list.Add(currentItem);

        return list;
    }

    public void LoadItems(List<string> loaded)
    {
        if (loaded != null && loaded.Count > 0)
        {
            currentItem = loaded[0];
            UIManager.instance.ShowItem(currentItem);
        }
        else
        {
            currentItem = "";
            UIManager.instance.HideItem();
        }
    }
}