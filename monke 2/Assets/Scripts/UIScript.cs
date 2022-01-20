﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameManager gameManager;

    [Header("UI Elements")]
    public TextMeshProUGUI ui_power;

    void Update()
    {
        // Check if dead
        if (gameManager.val_power > 0.0f)
        {
            // Round float to nearest whole number
            string powerText = Mathf.Round(gameManager.val_power).ToString();
            // Set color  
            ui_power.color = Color.white;
            // Set UI
            ui_power.text = powerText + "%";
        }
        else
        {
            // Set color
            ui_power.color = Color.red;
            // Set UI
            ui_power.text = "you're fucked.";
        }
    }
}