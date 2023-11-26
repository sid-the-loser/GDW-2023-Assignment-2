using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    Rigidbody2D _rb2D;
    private Vector2 _move;

    // Player attributes
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private int _health;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (_health != 0)
            {
                _health = value;
            }
        }
    }

    // If true player can jump
    private bool isGrounded;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _health = 1;
        Inputs.Init(this);
    }

    void Update()
    {
        transform.Translate(Vector2.right * (_speed * Time.deltaTime * _move.x), Space.Self);
        // Uses a boxcast underneath the player to check if the object under them has the layer "Platform"
        isGrounded = Physics2D.BoxCast(GetComponent<Collider2D>().bounds.center, GetComponent<Collider2D>().bounds.size, 0f, Vector2.down, 0.2f, platformLayerMask);

        if (_health == 0)
        {
            Die();
        }
    }

    public void Move(Vector2 direction)
    {
        _move = direction;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);
        }
    }

    public void Die()
    {

    }

}
