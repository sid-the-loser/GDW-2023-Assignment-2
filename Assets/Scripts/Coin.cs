using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UIManager manager;

    void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(manager._coinSfx, transform.position);
            UIManager.TotalCoins++;
            manager.UpdateCounter();
            Destroy(gameObject);
        }
    }

}
