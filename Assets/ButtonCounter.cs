using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCounter : MonoBehaviour
{
    private Text textToEdit;
    PlayerData playerData = new PlayerData();

    public void ChangeText()
    {
        playerData.totalClicks++;
        textToEdit.text = playerData.totalClicks.ToString();

        Debug.Log(playerData.totalClicks);

        if (playerData.totalClicks % 10 == 0)
            UG.Progress.Save("3d9ba3e4-0384-4890-b832-4c2f7b51bff5", 0, JsonUtility.ToJson(playerData));
    }

    private void Start()
    {
        textToEdit = GetComponentInChildren<Text>();

        playerData = UG.Progress.Load<PlayerData>("3d9ba3e4-0384-4890-b832-4c2f7b51bff5");
        Debug.Log("Loaded");

        textToEdit.text = playerData.totalClicks.ToString();
    }
}

[Serializable]
class PlayerData
{
    public int totalClicks = 0;
}
