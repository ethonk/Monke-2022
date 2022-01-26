using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [Header("Ingame?")]
    public bool ingame;
    public GameManager gameManager;

    [Header("Monkey Stats (Based on difficulty)")]
    [Tooltip("Move Speed - How often he switches positions.")]
    public int mke_gregory_pb;
    public static int mke_gregory;
    [Tooltip("Drain Rate - How much his pool drains per tick.")]
    public int mke_alfred_pb;
    public static int mke_alfred;
    [Tooltip("Patience - The minimum amount of time joey will wait for salad.")]
    public int mke_joey_pb;
    public static int mke_joey;
    [Tooltip("Frequency - How often the ad will show.")]
    public int mke_ads_pb;
    public static int mke_ads;
    [Tooltip("Move Speed - How often he switches positions.")]
    public int mke_johnathan_pb;
    public static int mke_johnathan;

    [Header("Monkey Stats (20 levels of difficulty)")]
    public List<float> mke_gregoryList      = new List<float>(21) {270.0f, 15.0f, 14.0f, 13.5f, 13.0f, 12.5f, 12.0f, 11.5f, 11.0f, 10.5f, 10.0f, 9.0f, 8.0f, 7.5f, 7.0f, 6.0f, 5.0f, 4.0f, 3.5f, 3.0f, 2.5f};
    public List<float> mke_alfredList       = new List<float>(21) {0.0f, 0.002f, 0.004f, 0.006f, 0.008f, 0.01f, 0.015f, 0.02f, 0.025f, 0.03f, 0.035f, 0.04f, 0.045f, 0.05f, 0.055f, 0.06f, 0.065f, 0.07f, 0.076f, 0.078f, 0.08f};
    public List<float> mke_joeyList         = new List<float>(21) {270.0f, 15.0f, 14.5f, 14.0f, 13.5f, 13.0f, 12.5f, 12.0f, 11.5f, 11.0f, 10.5f, 10.0f, 9.5f, 9.0f, 8.0f, 7.0f, 6.0f, 5.0f, 4.0f, 3.0f, 2.5f};
    public List<float> mke_adsList          = new List<float>(21) {270.0f, 54.0f, 50.0f, 48.0f, 45.0f, 40.0f, 36.0f, 32.0f, 28.0f, 24.0f, 20.0f, 18.0f, 16.0f, 14.0f, 12.0f, 11.0f, 10.0f, 9.0f, 8.0f, 7.0f, 6.0f};
    public List<float> mke_johnathanList    = new List<float>(21) {270.0f, 15.0f, 14.0f, 13.5f, 13.0f, 12.5f, 12.0f, 11.5f, 11.0f, 10.5f, 10.0f, 9.5f, 9.0f, 8.5f, 8.0f, 7.5f, 7.0f, 6.5f, 6.0f, 5.5f, 5.0f};

    void Start()
    {
        if (ingame)
        {
            // Assign difficulty modifiers
            gameManager.val_monkeMoveDelay      = mke_gregoryList[mke_gregory];
            gameManager.val_poolDrainRate       = mke_alfredList[mke_alfred];
            gameManager.val_saladMonkeMinWait   = mke_joeyList[mke_joey];
            gameManager.val_advertCooldown      = mke_adsList[mke_ads];
            gameManager.val_johnathanMoveDelay  = mke_johnathanList[mke_johnathan];
        }
    }

    public int GetJoeyDifficulty()
    {
        return mke_joey;
    }

    public void UpdateValues()
    {
        mke_gregory = mke_gregory_pb;
        mke_alfred = mke_alfred_pb;
        mke_joey = mke_joey_pb;
        mke_ads = mke_ads_pb;
        mke_johnathan = mke_johnathan_pb;
    }
}
