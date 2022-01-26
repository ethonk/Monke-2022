using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareHandler : MonoBehaviour
{
    public bool ste_jumpscared = false;

    [Header("Core")]
    public GameManager gameManager;

    [Header("Jumpscare Sounds")]
    public AudioClip snd_outOfPower;
    public AudioClip snd_bananaPoolJumpscare;

    [Header("Jumpscare Models")]
    public GameObject mdl_bananaPoolJumpscare;
    public GameObject mdl_saladMonkeyJumpscare;
    public GameObject mdl_monkeJumpscare;
    public GameObject mdl_johnathanJumpscare;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void DisableComponents()
    {
        GetComponent<GameManager>().ste_disabled = true;
    }

    public void DeactivateComponents()
    {
        // Close Tablet
        GetComponent<GameManager>().ste_tabletActive = false;
        // Switch Camera
        GetComponent<TabletScript>().SwitchToCamera(GetComponent<TabletScript>().cmr_office);
        // Close ad
        GetComponent<GameManager>().ui.ui_advertisement.gameObject.SetActive(false);
        GetComponent<GameManager>().ui.GetComponent<AudioSource>().Stop();
        // Reset camera position
        gameManager.cameras_master.StopRotate();
        gameManager.cameras_master.ResetRotation();
    }

    void Update()
    {
        if (!ste_jumpscared && gameManager.val_power <= 0)
            StartCoroutine(OutOfPower());
    }

    public IEnumerator OutOfPower()
    {
        // Set state to jumpscared.
        ste_jumpscared = true;
        gameManager.GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<AudioSource>().PlayOneShot(snd_outOfPower);
        yield return new WaitForSeconds(4.0f);
        JumpscareNoFilter(mdl_monkeJumpscare, snd_bananaPoolJumpscare);
    }

    public void Jumpscare(GameObject mdl, AudioClip snd)
    {
        if (!ste_jumpscared)
        {
            // Set state to jumpscared.
            ste_jumpscared = true;
            // Handle audio.
            GetComponent<AudioSource>().Stop();     // Stop all sounds
            GetComponent<AudioSource>().PlayOneShot(snd);
            // Handle model.
            mdl.SetActive(true);

            DisableComponents();
            DeactivateComponents();

            StartCoroutine(EndJumpscare());
        }
    }

    public void JumpscareNoFilter(GameObject mdl, AudioClip snd)
    {
        // Handle audio.
        GetComponent<AudioSource>().Stop();     // Stop all sounds
        GetComponent<AudioSource>().PlayOneShot(snd);
        // Handle model.
        mdl.SetActive(true);

        DisableComponents();
        DeactivateComponents();

        StartCoroutine(EndJumpscare());
    }

    public IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("GameOverScreen");
    }
}
