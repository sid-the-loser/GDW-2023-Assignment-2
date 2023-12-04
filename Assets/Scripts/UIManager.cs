using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinUI;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI sanityMeterUI;
    [SerializeField] private TextMeshProUGUI extraLifeUI;
    public static int TotalCoins = 0;
    
    public AudioClip _coinSfx;

    void Awake()
    {
        coinUI.text = "x00";
    }

    public void UpdateCounter()
    {
        if (TotalCoins < 10)
        {
            coinUI.text = $"C:0{TotalCoins}";
        }
        else
        {
            coinUI.text = $"C:{TotalCoins}";
        }
    }

    public void UpdateSanity(float sanityValue)
    {
        sanityMeterUI.text = $"S:{(int)(sanityValue * 100)}%";
    }
    
    public void UpdateExl(float exlValue)
    {
        extraLifeUI.text = $"LIVES:{exlValue}";
    }

    public void ObscureScreen()
    {
        panel.SetActive(true);
    }

    public void SetScreenNormal()
    {
        panel.SetActive(false);
    }
}
