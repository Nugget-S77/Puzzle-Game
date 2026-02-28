using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public int currentSlot = 0; // 0-2
    public float autoSaveInterval = 30f;

    float timer;
    string SavePath(int slot) =>
        Application.persistentDataPath + "/save_slot_" + slot + ".json";

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
        timer += Time.deltaTime;

        if (timer >= autoSaveInterval)
        {
            SaveGame(currentSlot);
            timer = 0f;
        }
    }

    public void SaveGame(int slot)
    {
        SaveData data = new SaveData();

        data.sceneName = SceneManager.GetActiveScene().name;

        var player = FindObjectOfType<PlayerController2D>();
        data.playerPosX = player.transform.position.x;
        data.playerPosY = player.transform.position.y;

        data.playTime = PlayTimeTracker.instance.currentTime;

        data.inventoryItems = Inventory.instance.GetItemList();

        Door[] doors = FindObjectsOfType<Door>();
        data.openedDoors = new List<string>();

        foreach (Door d in doors)
            if (d.isOpen)
                data.openedDoors.Add(d.doorID);

        HideSpot hide = FindObjectOfType<HideSpot>();
        data.isHidden = hide != null && hide.IsHidden();

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath(slot), json);

        Debug.Log("Saved Slot " + slot);
    }

    public void LoadGame(int slot)
    {
        if (!File.Exists(SavePath(slot))) return;

        string json = File.ReadAllText(SavePath(slot));
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        currentSlot = slot;

        StartCoroutine(LoadRoutine(data));
    }

    IEnumerator LoadRoutine(SaveData data)
    {
        yield return SceneManager.LoadSceneAsync(data.sceneName);
        yield return null;

        var player = FindObjectOfType<PlayerController2D>();
        player.transform.position =
            new Vector2(data.playerPosX, data.playerPosY);

        PlayTimeTracker.instance.currentTime = data.playTime;

        Inventory.instance.LoadItems(data.inventoryItems);

        Door[] doors = FindObjectsOfType<Door>();
        foreach (Door d in doors)
        {
            if (data.openedDoors.Contains(d.doorID))
            {
                d.isOpen = true;
                d.gameObject.SetActive(false);
            }
        }

        HideSpot hide = FindObjectOfType<HideSpot>();
        if (hide != null && data.isHidden)
            hide.ForceHide();

        Debug.Log("Loaded Slot " + currentSlot);
    }

    public bool HasSave(int slot)
    {
        return File.Exists(SavePath(slot));
    }

    public void DeleteSave(int slot)
    {
        if (File.Exists(SavePath(slot)))
            File.Delete(SavePath(slot));
    }
}