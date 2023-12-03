using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinUI;
    [SerializeField] private GameObject panel;
    private int totalCoins = 0;

    void Awake()
    {
        coinUI.text = "x00";
    }

    public void UpdateCounter()
    {
        totalCoins++;
        if (totalCoins < 10)
        {
            coinUI.text = $"x0{totalCoins}";
        }
        else
        {
            coinUI.text = $"x{totalCoins}";
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
