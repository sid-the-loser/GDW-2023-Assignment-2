using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType pType;
    private PlayerControl player;
    private bool isActive;
    private bool used;

    [SerializeField] private AudioClip sfx;

    // Enum which stores the different types of power ups
    public enum PowerUpType
    {
        IncreaseSanity,
        IncreaseHealth,
        MakeInvincible
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void Update()
    {
        // If a power up has been activated, that specific effect will be given to the player
        if (isActive && !used)
        {
            switch (pType)
            {
                case PowerUpType.IncreaseSanity:
                    Debug.Log("Sanity increased");
                    if (player.Sanity < 0.5f)
                    {
                        player.Sanity += 0.5f;
                    }
                    else
                    {
                        player.Sanity = 1f;
                    }
                    isActive = false;
                    used = true;
                    Destroy(this.gameObject);
                    break;
                case PowerUpType.IncreaseHealth:
                    Debug.Log("Health added");
                    player.Health++;
                    isActive = false;
                    used = true;
                    Destroy(this.gameObject);
                    break;
                case PowerUpType.MakeInvincible:
                    Debug.Log("Invulnerable");
                    isActive = false;
                    used = true;
                    StartCoroutine(player.OnBecameInvisible());
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !used)
        {
            // Sets the power up as active, and disables the object's collider and renderer so it can't be seen or picked up again
            isActive = true;
            AudioSource.PlayClipAtPoint(sfx, transform.position);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

}
