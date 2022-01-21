using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareHandler : MonoBehaviour
{
    public bool jumpscared = false;

    [Header("Jumpscare Sounds")]
    public AudioClip snd_bananaPoolJumpscare;

    [Header("Jumpscare Models")]
    public GameObject mdl_bananaPoolJumpscare;
    public GameObject mdl_saladMonkeyJumpscare;

    public void DeactivateComponents()
    {
        // Close Tablet
        GetComponent<GameManager>().ste_tabletActive = false;
        // Switch Camera
        GetComponent<TabletScript>().SwitchToCamera(GetComponent<TabletScript>().cmr_office);
    }

    public void Jumpscare(GameObject mdl, AudioClip snd)
    {
        jumpscared = true;
        GetComponent<AudioSource>().Stop();     // Stop all sounds
        GetComponent<AudioSource>().PlayOneShot(snd);
        print("sound played");
        mdl.SetActive(true);
        print("model spawned");

        DeactivateComponents();

        StartCoroutine(EndJumpscare());
    }

    public IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
