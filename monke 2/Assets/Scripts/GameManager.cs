using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("States")]
    public bool ste_tabletActive = false;

    [Header("Models")]
    public GameObject mdl_tablet;

    void Update()
    {   
        // Update the tablet
        if (Input.GetKeyDown(KeyCode.W))
        {
            ste_tabletActive = !ste_tabletActive;
            mdl_tablet.GetComponent<Animator>().SetBool("tablet-active", ste_tabletActive);
        }
    }
}
