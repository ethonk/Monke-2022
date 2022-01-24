using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPool : MonoBehaviour
{
    [Header("Core")]
    public GameManager gameManager;

    [Header("Values")]
    public float val_jumpscareDelay;

    [Header("States")]
    public bool ste_monkePresent = true;   // is the monkey still there

    [Header("Objects")]
    public Transform obj_poolWater;

    void Update()
    {
        // Monkey appear.
        if (ste_monkePresent == false)
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        else
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;

        // calc size (y)
        float newY = (gameManager.val_bananaPoolStartSize-gameManager.val_bananaPoolEndSize)*(gameManager.val_bananaPool/100);

        obj_poolWater.localScale = new Vector3(obj_poolWater.localScale.x, newY, obj_poolWater.localScale.z);

        // play warning sound
        if (gameManager.val_bananaPool >= 20.0f && gameManager.val_bananaPool <= 20.5f && !transform.Find("WarningSound").GetComponent<AudioSource>().isPlaying)
        {
            transform.Find("WarningSound").GetComponent<AudioSource>().PlayOneShot(gameManager.snd_poolMonkeyWarn);
        }

        // play monkey satisfaction sound if at 100%
        if (!GetComponent<AudioSource>().isPlaying && gameManager.val_bananaPool >= 99.0f)
            GetComponent<AudioSource>().PlayOneShot(gameManager.snd_poolMonkeySucceed);

        // do jumpscare
        if (gameManager.val_bananaPool <= 0 && ste_monkePresent)
        {
            ste_monkePresent = false;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(gameManager.snd_poolMonkeyFail);
            StartCoroutine(MonkeyPoolJumpscare());
        }
    }

    public IEnumerator MonkeyPoolJumpscare()
    {
        yield return new WaitForSeconds(val_jumpscareDelay);
        gameManager.GetComponent<JumpscareHandler>().Jumpscare(gameManager.GetComponent<JumpscareHandler>().mdl_bananaPoolJumpscare, gameManager.GetComponent<JumpscareHandler>().snd_bananaPoolJumpscare);
    }
}
