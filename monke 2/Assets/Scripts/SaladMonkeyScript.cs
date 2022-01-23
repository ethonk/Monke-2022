using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladMonkeyScript : MonoBehaviour
{
    [Header("Core")]
    public GameManager gameManager;

    [Header("Private Stats")]
    public float val_minWait = 5.0f;
    public float val_maxWait = 12.0f;
    [Header("Private States")]
    public bool ste_pissedOff = false;
    [Header("Salad Stuff")]
    public List<string> ingredients;

    [Header("Generated")]
    public float waitTimeWarning;
    public float waitTime;
    public string currentIngredient;

    void Start()
    {
        StartCoroutine(RequestSalad());
    }
    void Update()
    {
        // Disappear on piss off
        if (ste_pissedOff)
        {
            GetComponent<MeshRenderer>().enabled = false;
            currentIngredient = "none";
        }

        // Update UI
        gameManager.val_saladMonkeyRequest = currentIngredient;
    }

    public IEnumerator RequestSalad()
    {
        // generate random list member
        int listIndex = Random.Range(0, ingredients.Count);
        currentIngredient = ingredients[listIndex];
        yield return new WaitForSeconds(GenerateRandomWait()-waitTimeWarning);
        // Play warning
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(gameManager.snd_saladMonkeyWarning);
        yield return new WaitForSeconds(waitTimeWarning);
        // Jumpscare
        StopAllCoroutines();
        StartCoroutine(Jumpscare());
    }

    // Answers
    public void AnswerBanana()
    {
        if (currentIngredient == "banana")
        {
            StopAllCoroutines();
            StartCoroutine(RequestSalad());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(Jumpscare());
        }
    }
    public void AnswerCheese()
    {
        if (currentIngredient == "cheese")
        {
            StopAllCoroutines();
            StartCoroutine(RequestSalad());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(Jumpscare());
        }
    }
    public void AnswerLice()
    {
        if (currentIngredient == "lice")
        {
            StopAllCoroutines();
            StartCoroutine(RequestSalad());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(Jumpscare());
        }
    }

    float GenerateRandomWait()
    {
        float _waitTime = Random.Range(val_minWait, val_maxWait);
        waitTime = _waitTime;
        return _waitTime;
    }

    public IEnumerator Jumpscare()
    {
        // Make pissed
        ste_pissedOff = true;
        // Play sound
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(gameManager.snd_saladMonkeyDispleasure);
        yield return new WaitForSeconds(8.0f);
        // Jumpscare script
        if (!gameManager.GetComponent<JumpscareHandler>().jumpscared)
        {
            gameManager.GetComponent<JumpscareHandler>().Jumpscare(gameManager.GetComponent<JumpscareHandler>().mdl_saladMonkeyJumpscare, gameManager.GetComponent<JumpscareHandler>().snd_bananaPoolJumpscare);
        }
    }
}
