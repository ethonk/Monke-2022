using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletScript : MonoBehaviour
{
    [Header("Currently Active Camera")]
    public Camera cmr_active;

    [Header("Cameras")]
    public Camera cmr_office;
    public Camera cmr_janitor;
    public Camera cmr_kitchen;
    public Camera cmr_electrical;
    public Camera cmr_entrance;
    public Camera cmr_enclosure;
    public Camera cmr_hallway;
    public Camera cmr_airSystems;

    public void SwitchToCamera(Camera cam)
    {
        cmr_active.gameObject.SetActive(false);
        cmr_active = cam;
        cmr_active.gameObject.SetActive(true);
    }
}
