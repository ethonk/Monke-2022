using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    public bool isGameOver;
    public Image image;
    public AudioClip snd_nightFinish;

    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(snd_nightFinish);
        if (isGameOver)
        {
            StartCoroutine(SendToMenu());
        }
    }

    IEnumerator SendToMenu()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<AudioSource>().Stop();
        image.color = new Color32(0,0,0,255);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("GameMenu");
    }

    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
