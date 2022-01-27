using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public TextMeshProUGUI ui_time;
    public GameObject ui_saladOptions;
    public Image ui_saladRequest;
    public GameObject ui_saladRequestOptions;
    public Image ui_advertisement;
    public GameObject ui_cameraControls;
    public GameObject ui_glitch;

    [Header("UI Elements - Camera UI Specifics")]
    public GameObject ui_bananaPool;

    [Header("Advertisement - Random Button Position")]
    public List<Vector3> ad_buttonPos;

    void Start()
    {
        StartCoroutine(Advertisement());
    }

    void Update()
    {
        // Create time
        int time;
        if (gameManager.val_time == 0)
            time = 12;
        else
            time = gameManager.val_time;
        // Update Time
        ui_time.text = time.ToString() + "AM";

        //
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

        // Update current ingredient
        switch(gameManager.val_saladMonkeyRequest)
        {
            case "banana":
                ui_saladRequest.sprite = gameManager.img_banana;
                break;
            case "cheese":
                ui_saladRequest.sprite = gameManager.img_cheese;
                break;
            case "lice":
                ui_saladRequest.sprite = gameManager.img_lice;
                break;
        }
        // Showing the salad minigame. 
        if (gameManager.val_saladMonkeyRequest == "none")
        {
            ui_saladRequestOptions.SetActive(false);
        }
    }

    void CameraUISpecifics()
    {
        // Moving camera left and right
        if (gameManager.ste_disabled || gameManager.ste_tabletActive)
        {
            ui_cameraControls.SetActive(false);
            gameManager.cameras_master.StopRotate();
            gameManager.cameras_master.ResetRotation();
        }
        else
            ui_cameraControls.SetActive(true);

        // Banana Pool UI
        if (tabletScript.cmr_active == tabletScript.cmr_enclosure && !gameManager.ste_poolPissed)
            ui_bananaPool.SetActive(true);
        else    
            ui_bananaPool.SetActive(false);
        // Salad UI
        if(tabletScript.cmr_active == tabletScript.cmr_kitchen)
            ui_saladOptions.SetActive(true);
        else
            ui_saladOptions.SetActive(false);
    }

    public IEnumerator Advertisement()
    {
        yield return new WaitForSeconds(gameManager.val_advertCooldown);
        // Run ad if ad is not already active and if player isnt being jumpscared.
        if (!ui_advertisement.gameObject.activeInHierarchy && !gameManager.GetComponent<JumpscareHandler>().ste_jumpscared)
        {
            ui_advertisement.gameObject.SetActive(true);
            ui_advertisement.sprite = gameManager.GenerateBananaAdvertImage();
            
            // generate random button positions
            int index = Random.Range(0, ad_buttonPos.Count-1);
            Vector3 buttonPos = ad_buttonPos[index];
            ui_advertisement.transform.Find("Close").localPosition = buttonPos;

            transform.root.GetComponent<AudioSource>().PlayOneShot(gameManager.snd_bananaPoster);
        }
        StartCoroutine(Advertisement());
    }

    public void CloseAdvertisement()
    {
        transform.root.GetComponent<AudioSource>().Stop();
        ui_advertisement.gameObject.SetActive(false);
    }

    public void SetGlitch(bool _active)
    {
        ui_glitch.SetActive(_active);
    }
}
