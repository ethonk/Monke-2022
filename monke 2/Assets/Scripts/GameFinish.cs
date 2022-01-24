using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    public AudioClip snd_nightFinish;

    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(snd_nightFinish);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
