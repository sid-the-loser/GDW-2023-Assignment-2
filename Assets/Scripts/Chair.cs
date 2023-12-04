using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Chair : MonoBehaviour
{
    enum ChairType
    {
        
        LoseChair,
        WinningChair
        
    }

    [SerializeField] private ChairType chairType; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chair entered");
            if (chairType == ChairType.LoseChair)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                SceneManager.LoadScene("EndScreen");
            }
        }
    }
}
