using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType pType;
    private PlayerControl player;
    private bool isActive;

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
        if (isActive)
        {
            switch (pType)
            {
                case PowerUpType.IncreaseSanity:
                    Debug.Log("Increased sanity");
                    isActive = false;
                    break;
                case PowerUpType.IncreaseHealth:
                    player.Health++;
                    Debug.Log("Increased health");
                    isActive = false;
                    break;
                case PowerUpType.MakeInvincible:
                    Debug.Log("Invulnerable");
                    isActive = false;
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Sets the power up as active, and disables the object's collider and renderer so it can't be seen or picked up again
            isActive = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

}
