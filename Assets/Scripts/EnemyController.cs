using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;

    Rigidbody2D rb2D;
    PlayerControl player;

    [SerializeField] private float speed;
    private bool movingLeft = true;
    private bool headStomped = false;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void Update()
    {
        if (movingLeft)
        {
            transform.Translate(Vector2.right * (speed * Time.deltaTime), Space.Self);
            // Uses rigidbody to move creating more natural movement
            //rb2D.velocity += new Vector2(speed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(Vector2.left * (speed * Time.deltaTime), Space.Self);
            //rb2D.velocity += new Vector2(-speed * Time.deltaTime, 0);
        }

        if (transform.position.y < -12)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // Using a boxcast checking if the player is directly on top of the enemy
        headStomped = Physics2D.BoxCast(GetComponent<Collider2D>().bounds.center, GetComponent<Collider2D>().bounds.size - new Vector3(0.4f, 0, 0), 0f, Vector2.up, 0.1f, playerLayerMask);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && headStomped == true)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && headStomped == false)
        {
            Debug.Log("Damaged player");
            player.TakeDamage();
        }
        else
        {
            movingLeft = !movingLeft;
        }
    }

}
