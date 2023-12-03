using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    Rigidbody2D _rb2D;
    private Vector2 _move;
    private Camera _camera;

    // Player attributes
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private int _health;
    private float _sanity;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (_health == 1)
            {
                _health = value;
            }
        }
    }

    public float Sanity
    {
        get
        {
            return _sanity;
        }
        set
        {
            if (_sanity != 0)
            {
                _sanity = value;
            }
        }
    }

    // If true player can jump
    private bool isGrounded;
    // When true, the coroutine won't be called, so the player's sanity won't decrease every frame
    private bool isSanityDraining;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _health = 1;
        _sanity = 1f;
        Inputs.Init(this);
    }

    void Update()
    {
        if (_sanity > 0.75f)
        {
            transform.Translate(Vector2.right * (_speed * Time.deltaTime * _move.x), Space.Self);
        }
        else if (_sanity <= 0.75f)
        {
            float slowSpeed = _speed * 0.75f;
            transform.Translate(Vector2.right * (slowSpeed * Time.deltaTime * _move.x), Space.Self);
        }
        // Makes the camera follow the x-position of the player
        _camera.transform.position = new Vector3(transform.position.x, 0, -10);

        if (!isSanityDraining)
        {
            StartCoroutine(SanityDrain());
        }

        if (_health <= 0 || _sanity <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        // Uses a boxcast underneath the player to check if the object under them has the layer "Platform"
        isGrounded = Physics2D.BoxCast(GetComponent<Collider2D>().bounds.center, GetComponent<Collider2D>().bounds.size, 0f, Vector2.down, 0.2f, platformLayerMask);
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

    public void TakeDamage()
    {
        _health--;
    }

    IEnumerator SanityDrain()
    {
        isSanityDraining = true;
        yield return new WaitForSeconds(1);
        _sanity -= 0.01f;
        isSanityDraining = false;
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
