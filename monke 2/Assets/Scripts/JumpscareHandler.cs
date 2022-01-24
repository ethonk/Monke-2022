using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareHandler : MonoBehaviour
{
    public bool ste_jumpscared = false;

    [Header("Jumpscare Sounds")]
    public AudioClip snd_bananaPoolJumpscare;

    [Header("Jumpscare Models")]
    public GameObject mdl_bananaPoolJumpscare;
    public GameObject mdl_saladMonkeyJumpscare;
    public GameObject mdl_monkeJumpscare;

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

    public IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
