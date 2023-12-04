using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinUI;
    [SerializeField] private GameObject panel;
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
            coinUI.text = $"x0{TotalCoins}";
        }
        else
        {
            coinUI.text = $"x{TotalCoins}";
        }
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
