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

    public void JumpscareBananaPool()
    {
        jumpscared = true;
        GetComponent<AudioSource>().Stop();     // Stop all sounds
        GetComponent<AudioSource>().PlayOneShot(snd_bananaPoolJumpscare);
        mdl_bananaPoolJumpscare.SetActive(true);

        // Close Tablet
        GetComponent<GameManager>().ste_tabletActive = false;
        // Switch Camera
        GetComponent<TabletScript>().SwitchToCamera(GetComponent<TabletScript>().cmr_office);

        StartCoroutine(EndJumpscare());
    }

    public IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
