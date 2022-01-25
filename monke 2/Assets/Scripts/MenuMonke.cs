using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuMonke : MonoBehaviour
{
    public int val_level;
    public TextMeshProUGUI tmp_levelText;

    void Update()
    {
        tmp_levelText.text = val_level.ToString();

        // handling visibility
        if (val_level == 0)
        {
            var tempColor = GetComponent<Image>().color;
            tempColor.a = 0.1f;
            GetComponent<Image>().color = tempColor;
        }
        else
        {
            var tempColor = GetComponent<Image>().color;
            tempColor.a = 1.0f;
            GetComponent<Image>().color = tempColor;
        }
    }
}
