using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeJohnathan : MonoBehaviour
{
    [Header("Game Manager")]
    public GameManager gameManager;

    [Header("Stats")]
    public float val_waitTime;

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
        yield return new WaitForSeconds(gameManager.val_johnathanMoveDelay);
        transform.root.position = positions[positionIndex];
        currentPosition = positions[positionIndex];
        positionIndex++;

        if (positionIndex == positions.Count)   // If maximum has reached, reset position.
        {
            yield return new WaitForSeconds(val_waitTime);
            // Move monke back
            positionIndex = 0;
            transform.root.position = positions[positionIndex];
            currentPosition = positions[positionIndex];
            // If mask isn't on, jumpscare
            if(!gameManager.ste_maskActive)
                gameManager.GetComponent<JumpscareHandler>().Jumpscare(gameManager.GetComponent<JumpscareHandler>().mdl_johnathanJumpscare, gameManager.GetComponent<JumpscareHandler>().snd_bananaPoolJumpscare);
            
        }

        StartCoroutine(MoveMonke());
    }
}
