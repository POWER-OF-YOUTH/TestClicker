using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCounter : MonoBehaviour
{
    Text textToEdit;
    PlayerData playerData = new PlayerData();

    void Start()
    {
        textToEdit = GetComponentInChildren<Text>();

        playerData = JsonUtility.FromJson<PlayerData>(UG.Progress.Load());

        textToEdit.text = playerData.totalClicks.ToString();
    }

    public void ChangeText()
    {
        playerData.totalClicks++;
        textToEdit.text = playerData.totalClicks.ToString();

        if (playerData.totalClicks % 10 == 0) {
            string json = JsonUtility.ToJson(playerData);

            Debug.Log($"[Game] Prepare to save `{json}`.");
            
            UG.Progress.Save(json);
        }
    }
}

[Serializable]
class PlayerData
{
    public int totalClicks = 0;
}
