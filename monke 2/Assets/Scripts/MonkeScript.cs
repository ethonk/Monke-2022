using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeScript : MonoBehaviour
{
    [Header("Game Manager")]
    public GameManager gameManager;

    [Header("Position Data")]
    public int positionIndex = 0;   // Do not modify.
    public Vector3 currentPosition; // Do not modify.
    public List<Vector3> positions;

    // Start is called before the first frame update
    void Start()
    {
        // Find gamemanager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // Move monke
        StartCoroutine(MoveMonke());
    }

    // Move the Monke
    public IEnumerator MoveMonke()
    {
        yield return new WaitForSeconds(gameManager.val_monkeMoveDelay);
        transform.root.position = positions[positionIndex];
        currentPosition = positions[positionIndex];
        positionIndex++;

        if (positionIndex == positions.Count)   // If maximum has reached, reset position.
        {
            // Move monke back
            positionIndex = 0;
            transform.root.position = positions[positionIndex];
            currentPosition = positions[positionIndex];
            // If door not closed, jumpscare.
            if (!gameManager.ste_mainDoorActive)
                gameManager.GetComponent<JumpscareHandler>().Jumpscare(gameManager.GetComponent<JumpscareHandler>().mdl_monkeJumpscare, gameManager.GetComponent<JumpscareHandler>().snd_bananaPoolJumpscare);
            // If door closed
            gameManager.mdl_mainDoor.GetComponent<AudioSource>().Stop();
            gameManager.mdl_mainDoor.GetComponent<AudioSource>().PlayOneShot(gameManager.snd_doorKnocking);
            
        }

        StartCoroutine(MoveMonke());
    }
}
