using System;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int saveVersion = 1;

    public string sceneName;

    public float playerPosX;
    public float playerPosY;

    public float playTime;

    public List<string> inventoryItems;

    public List<string> openedDoors;

    public bool isHidden;
}