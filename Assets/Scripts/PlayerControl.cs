using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    Rigidbody2D _rb2D;
    private Vector2 _move;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool isGrounded;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        Inputs.Init(this);
    }

    void Update()
    {
        transform.Translate(Vector2.right * (_speed * Time.deltaTime * _move.x), Space.Self);
        isGrounded = Physics2D.Raycast(GetComponent<Collider2D>().bounds.center, Vector2.down, GetComponent<Collider2D>().bounds.extents.y + 0.1f, platformLayerMask);
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

}
