using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPool : MonoBehaviour
{
    [Header("States")]
    public bool ste_monkePresent = true;   // is the monkey still there

    public Transform obj_poolWater;
    public GameManager gameManager;

    void Update()
    {
        // calc size (y)
        float newY = (gameManager.val_bananaPoolStartSize-gameManager.val_bananaPoolEndSize)*(gameManager.val_bananaPool/100);

        obj_poolWater.localScale = new Vector3(obj_poolWater.localScale.x, newY, obj_poolWater.localScale.z);

        // task failure handler
        if (gameManager.val_bananaPool == 0 && ste_monkePresent)
        {
            ste_monkePresent = false;
            GetComponent<AudioSource>().PlayOneShot(gameManager.snd_ballpitTaskFail);
        }

        // play monkey satisfaction sound if at 100%
        if (!GetComponent<AudioSource>().isPlaying && gameManager.val_bananaPool >= 99.0f)
            GetComponent<AudioSource>().PlayOneShot(gameManager.snd_ballpitTaskSucceed);
    }
}
