using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCounter : MonoBehaviour
{
    private Text textToEdit;
    private int totalClicks = 0;
    void Start()
    {
        textToEdit = GetComponentInChildren<Text>();
    }

    public void ChangeText()
    {
        totalClicks += 1;
        textToEdit.text = totalClicks.ToString();
    }
}
