using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPool : MonoBehaviour
{
    public Transform obj_poolWater;
    public GameManager gameManager;

    void Update()
    {
        // calc size (y)
        float newY = (gameManager.val_bananaPoolStartSize-gameManager.val_bananaPoolEndSize)*(gameManager.val_bananaPool/100);

        obj_poolWater.localScale = new Vector3(obj_poolWater.localScale.x, newY, obj_poolWater.localScale.z);
    }
}
