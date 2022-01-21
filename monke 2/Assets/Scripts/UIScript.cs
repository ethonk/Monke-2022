using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [Header("Core Scripts")]
    public GameManager gameManager;
    public TabletScript tabletScript;

    [Header("UI Elements - General")]
    public GameObject ui_cameraStatic;
    public GameObject ui_roomButtons;
    public TextMeshProUGUI ui_power;
    [Header("UI Elements - Camera UI Specifics")]
    public GameObject ui_bananaPool;

    void Update()
    {
        CameraUISpecifics();

        // Camera Static Toggle
        ui_cameraStatic.SetActive(gameManager.ste_tabletActive);
        ui_roomButtons.SetActive(gameManager.ste_tabletActive);

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

    void CameraUISpecifics()
    {
        // Banana Pool UI
        if (tabletScript.cmr_active == tabletScript.cmr_enclosure)
            ui_bananaPool.SetActive(true);
        else    
            ui_bananaPool.SetActive(false);
    }
}
