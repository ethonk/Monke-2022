using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{  
    [Header("Moving")]
    public bool moving;
    public int multiplier;
    public float rotSpeed;
    public float maxDirection;
    public Transform main_camera;
    
    public void Rotate(int _multiplier)
    {
        moving = true;
        multiplier = _multiplier;
    }

    public void StopRotate()
    {
        moving = false;
        multiplier = 0;
    }

    public void ResetRotation()
    {
        main_camera.transform.rotation = new Quaternion(0, 0, 0, 1.0f);
    }

    void Update()
    {
        if (moving)
            if (main_camera.transform.localRotation.y > -1*maxDirection && multiplier == -1)
                main_camera.Rotate(0,rotSpeed*multiplier*Time.deltaTime,0,Space.Self);
            if (main_camera.transform.localRotation.y < maxDirection && multiplier == 1)
                main_camera.Rotate(0,rotSpeed*multiplier*Time.deltaTime,0,Space.Self); 
    }
}
