using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Core")]
    public UIScript ui;

    [Header("Values")]
    public int val_time             = 0;
    public int val_finishingTime    = 6;
    public float val_nightDuration  = 270.0f;
    public float val_power          = 100.0f;
    public float val_drainRate      = 0.005f;
    // Banana Pool
    public float val_bananaPool     = 95.0f;
    public float val_poolDrainRate  = 0.02f;
    public float val_poolFillRate   = 10.0f;
    public float val_bananaPoolStartSize = 2.867768f;
    public float val_bananaPoolEndSize   = 0.09633824f;
    public string val_saladMonkeyRequest = "banana";
    public float val_advertCooldown = 5.0f;

    [Header("States")]
    public bool ste_disabled        = false;
    public bool ste_tabletActive    = false;
    public bool ste_maskActive      = false;

    [Header("States - Doors")]
    public bool ste_mainDoorActive  = false;

    [Header("Models")]
    public GameObject mdl_tablet;
    public GameObject mdl_mask;

    [Header("Cameras")]
    public Camera cmr_main;
    
    [Header("Doors")]
    public GameObject mdl_mainDoor;

    [Header("Sounds")]
    public AudioClip snd_phoneGuy;
    // mask
    public AudioClip snd_maskOn;
    public AudioClip snd_maskOff;
    // ball pit
    public AudioClip snd_ballpitTaskFail;
    public AudioClip snd_ballpitTaskSucceed;
    // salad monkey
    public AudioClip snd_saladMonkeyDispleasure;
    public AudioClip snd_saladMonkeyPleasure;
    public AudioClip snd_saladMonkeyWarning;
    public AudioClip snd_doorSlam;

    [Header("Salad Images")]
    public Sprite img_banana;
    public Sprite img_cheese;
    public Sprite img_lice;

    [Header("Banana Posters")]
    public Sprite ui_bananaPoster1;
    public Sprite ui_bananaPoster2;
    public AudioClip snd_bananaPoster;  

    void Start()
    {
        // Start phone call
        GetComponent<AudioSource>().PlayOneShot(snd_phoneGuy);
        // Start ticking time
        StartCoroutine(TimePass());
    }

    void Update()
    {   
        InputHandler();     // Handle all the input.
        ValueHandler();     // Handle all the values.
        // Die on power outage
        if (val_power <= 0)
            SceneManager.LoadScene("GameOverScreen");
    }

    void InputHandler()
    {
        #region Sync stats with animator
        // Update the tablet
        mdl_tablet.GetComponent<Animator>().SetBool("tablet-active", ste_tabletActive);
        // Update the mask
            mdl_mask.GetComponent<Animator>().SetBool("mask-active", ste_maskActive);
        #endregion

        #region Components that are affected by disability.
        if (!ste_disabled)
        {
            // Tablet
            if (Input.GetKeyDown(KeyCode.S) && !ste_maskActive)     // If key press && mask not active
            {
                if (ste_tabletActive)   // Close camera
                    GetComponent<TabletScript>().SwitchToCamera(cmr_main);
                ste_tabletActive = !ste_tabletActive;
                mdl_tablet.GetComponent<Animator>().SetBool("tablet-active", ste_tabletActive);
            }
            // Mask
            if (Input.GetKeyDown(KeyCode.Q) && !ste_tabletActive)    // If key press && tablet not active
            {
                // Handle sound
                mdl_mask.GetComponent<AudioSource>().Stop();
                if (ste_maskActive)
                    mdl_mask.GetComponent<AudioSource>().PlayOneShot(snd_maskOff);
                else
                    mdl_mask.GetComponent<AudioSource>().PlayOneShot(snd_maskOn);
                // Handle mask
                ste_maskActive = !ste_maskActive;
                mdl_mask.GetComponent<Animator>().SetBool("mask-active", ste_maskActive);
            }

            // == DOORS ==
            // Update the Main Door
            if (Input.GetKeyDown(KeyCode.W))    // If key press
            {
                ste_mainDoorActive = !ste_mainDoorActive;
                mdl_mainDoor.GetComponent<Animator>().SetBool("door-active", ste_mainDoorActive);
                // play sound
                mdl_mainDoor.GetComponent<AudioSource>().Stop();
                mdl_mainDoor.GetComponent<AudioSource>().PlayOneShot(snd_doorSlam);
            }
        }
        #endregion
    }
    
    void ValueHandler()
    {
        // == DOOR POWER ==
        // If the main door is active, drain power.
        if (ste_mainDoorActive)
            val_power -= val_drainRate;

        // == OTHER POWER ==
        // If the tablet is active, drain power.
        if (ste_tabletActive)
            val_power -= val_drainRate;

        // == BANANA POOL ==
        if (val_bananaPool > 0)
            val_bananaPool -= val_poolDrainRate;        // Otherwise, drain.
            if (val_bananaPool < 0)
                val_bananaPool = 0;     // Clamp
    }

    public void FillBananaPool()
    {
        if (val_bananaPool < 100.0f)
            val_bananaPool += val_poolFillRate;
            if (val_bananaPool > 100.0f)
                val_bananaPool = 100.0f;    // Clamp.
    }

    public Sprite GenerateBananaAdvertImage()
    {
        int rando = Random.Range(1,3);

        switch(rando)
        {
            case 1:
                return ui_bananaPoster1;
            case 2:
                return ui_bananaPoster2;
        }

        // default
        return ui_bananaPoster1;
    }

    public IEnumerator TimePass()
    {
        yield return new WaitForSeconds(val_nightDuration/val_finishingTime);
        if (val_time == val_finishingTime)
        {
            // end the night
            SceneManager.LoadScene("GameWinScene");
        }
        else
        {
            val_time++;
            StartCoroutine(TimePass());
        }
    }
}
