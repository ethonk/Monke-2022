using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("States")]
    public bool ste_tabletActive = false;
    public bool ste_maskActive   = false;

    [Header("Models")]
    public GameObject mdl_tablet;
    public GameObject mdl_mask;

    void Update()
    {   
        // Update the tablet
        if (Input.GetKeyDown(KeyCode.S) && !ste_maskActive)     // If key press && mask not active
        {
            ste_tabletActive = !ste_tabletActive;
            mdl_tablet.GetComponent<Animator>().SetBool("tablet-active", ste_tabletActive);
        }

        // Update the mask
        if (Input.GetKeyDown(KeyCode.Q) && !ste_tabletActive)    // If key press && tablet not active
        {
            ste_maskActive = !ste_maskActive;
            mdl_mask.GetComponent<Animator>().SetBool("mask-active", ste_maskActive);
        }
    }
}
