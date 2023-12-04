using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ScoreBoardScore : MonoBehaviour
{
    private TextMeshProUGUI _tmp;

    private void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
        
        if (_tmp is null)
        {
            Debug.Log("Wtf");
        }
        else
        {
            _tmp.text = $"Score: {UIManager.TotalCoins}\n\n\nPress Enter to Restart";
            UIManager.TotalCoins = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
