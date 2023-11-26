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
    }

    void Update()
    {
        if (movingLeft)
        {
            transform.Translate(Vector2.right * (speed * Time.deltaTime), Space.Self);
        }
        else
        {
            transform.Translate(Vector2.left * (speed * Time.deltaTime), Space.Self);
        }

        headStomped = Physics2D.BoxCast(GetComponent<Collider2D>().bounds.max, GetComponent<Collider2D>().bounds.size, 0f, Vector2.up, 0.1f, playerLayerMask);

        if (transform.position.y < -12)
        {
            Destroy(gameObject);
        }
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
            //player.Health--;
            movingLeft = !movingLeft;
        }
        else
        {
            movingLeft = !movingLeft;
        }
    }

}
