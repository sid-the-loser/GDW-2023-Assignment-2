using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb2D;

    [SerializeField] private float speed;
    private bool movingLeft = true;

    void Start()
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
        else
        {
            movingLeft = !movingLeft;
        }
    }

}
