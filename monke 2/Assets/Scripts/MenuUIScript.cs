using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIScript : MonoBehaviour
{
    [Header("Core")]
    public GameObject obj_currentButton;
    public GameObject obj_upDown;
    public GameObject obj_allMonke;
    public Difficulty obj_difficulty;

    public void OnClick()
    {
        obj_currentButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        // Set button
        obj_upDown.SetActive(true);
        obj_upDown.transform.SetParent(obj_currentButton.transform);
        obj_upDown.transform.localPosition = Vector3.zero;
        obj_upDown.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }

    public void IncreaseByOne()
    {
        if (obj_currentButton.GetComponent<MenuMonke>().val_level < 20)
            obj_currentButton.GetComponent<MenuMonke>().val_level += 1;
    }

    public void DecreaseByOne()
    {
        if (obj_currentButton.GetComponent<MenuMonke>().val_level > 0)
            obj_currentButton.GetComponent<MenuMonke>().val_level -= 1;
    }

    public void SetAll(int _lvl)
    {
        for (int i = 0; i < obj_allMonke.transform.childCount; i++)
        {
            obj_allMonke.transform.GetChild(i).GetComponent<MenuMonke>().val_level = _lvl;
        }
    }

    public void BeginGame()
    {
        obj_difficulty.mke_gregory_pb = obj_allMonke.transform.GetChild(0).GetComponent<MenuMonke>().val_level;
        obj_difficulty.mke_alfred_pb = obj_allMonke.transform.GetChild(1).GetComponent<MenuMonke>().val_level;
        obj_difficulty.mke_joey_pb = obj_allMonke.transform.GetChild(2).GetComponent<MenuMonke>().val_level;
        obj_difficulty.mke_ads_pb = obj_allMonke.transform.GetChild(3).GetComponent<MenuMonke>().val_level;
        obj_difficulty.UpdateValues();
        
        SceneManager.LoadScene("GameScene");
    }

    public void Preset()
    {
        // Define button
        MenuDefaultMonkes menuDefaultMonkes = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<MenuDefaultMonkes>();
        // Set all 0
        SetAll(0);
        // Set all monke in button
        foreach (MenuMonke monke in menuDefaultMonkes.monkes)
        {
            monke.val_level = menuDefaultMonkes.difficulty;
        }
    }
}
