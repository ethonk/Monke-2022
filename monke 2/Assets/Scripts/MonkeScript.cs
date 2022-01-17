using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeScript : MonoBehaviour
{
    [Header("Position Data")]
    public int positionIndex = 0;   // Do not modify.
    public Vector3 currentPosition; // Do not modify.
    public List<Vector3> positions;

    [Header("Movement Data")]
    public float moveDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveMonke());
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Move the Monke
    public IEnumerator MoveMonke()
    {
        yield return new WaitForSeconds(moveDelay);
        transform.root.position = positions[positionIndex];
        currentPosition = positions[positionIndex];
        positionIndex++;

        if (positionIndex == positions.Count)   // If maximum has reached, reset position.
        {
            positionIndex = 0;
        }

        StartCoroutine(MoveMonke());
    }

    // Run Jumpscare
    void Jumpscare()
    {

    }
}
