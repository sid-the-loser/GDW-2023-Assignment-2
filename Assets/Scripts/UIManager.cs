using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinUI;
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
}
