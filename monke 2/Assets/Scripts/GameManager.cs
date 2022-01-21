﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Values")]
    public float val_power          = 100.0f;
    public float val_drainRate      = 0.005f;
    // Banana Pool
    public float val_bananaPool     = 100.0f;
    public float val_poolDrainRate  = 0.01f;
    public float val_poolFillRate   = 0.1f;
    public float val_bananaPoolStartSize = 3.106382f;
    public float val_bananaPoolEndSize   = 0.200000f;

    [Header("States")]
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
    public AudioClip snd_ballpitTaskFail;
    public AudioClip snd_ballpitTaskSucceed;

    void Update()
    {   
        InputHandler();     // Handle all the input.
        ValueHandler();     // Handle all the values.
        
        // Test Jumpscare
        if (val_bananaPool == 0)
            if (GetComponent<JumpscareHandler>().jumpscared == false)
            {
                GetComponent<JumpscareHandler>().JumpscareBananaPool();
            }
    }

    void InputHandler()
    {
        // Update the tablet
        mdl_tablet.GetComponent<Animator>().SetBool("tablet-active", ste_tabletActive);
        if (Input.GetKeyDown(KeyCode.S) && !ste_maskActive)     // If key press && mask not active
        {
            if (ste_tabletActive)   // Close camera
                GetComponent<TabletScript>().SwitchToCamera(cmr_main);
            ste_tabletActive = !ste_tabletActive;
            mdl_tablet.GetComponent<Animator>().SetBool("tablet-active", ste_tabletActive);
        }

        // Update the mask
        mdl_mask.GetComponent<Animator>().SetBool("mask-active", ste_maskActive);
        if (Input.GetKeyDown(KeyCode.Q) && !ste_tabletActive)    // If key press && tablet not active
        {
            ste_maskActive = !ste_maskActive;
            mdl_mask.GetComponent<Animator>().SetBool("mask-active", ste_maskActive);
        }

        // == DOORS ==
        // Update the Main Door
        if (Input.GetKeyDown(KeyCode.W))    // If key press
        {
            ste_mainDoorActive = !ste_mainDoorActive;
            mdl_mainDoor.GetComponent<Animator>().SetBool("door-active", ste_mainDoorActive);
        }
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
}
