using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private UIManager manager;

    Rigidbody2D _rb2D;
    private Vector2 _move;
    private Camera _camera;

    // Player attributes
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private int _health;
    private float _sanity;

    [SerializeField] private AudioClip jumpSfx;

    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite invincibleSprite;
    private SpriteRenderer _spriteRenderer;

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

    private bool isInvincible;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _camera = Camera.main;
        manager = GameObject.Find("GameManager").GetComponent<UIManager>();
        _health = 1;
        _sanity = 1f;
        Inputs.Init(this);
        Inputs.SetPlayerControls();
    }

    void Update()
    {
        if (_sanity > 0.75f)
        {
            transform.Translate(Vector2.right * (_speed * Time.deltaTime * _move.x), Space.Self);
            // _rb2D.velocity = new Vector2(_speed*_move.x, _rb2D.velocity.y);// tried fixing the gitter effect when colliding with blocks, didn't work
        }
        else if (_sanity <= 0.75f)
        {
            float slowSpeed = _speed * 0.75f;
            transform.Translate(Vector2.right * (slowSpeed * Time.deltaTime * _move.x), Space.Self);
        }

        if (_sanity > 0.5f)
        {
            manager.SetScreenNormal();
        }
        else if (_sanity <= 0.5f)
        {
            manager.ObscureScreen();
        }

        // Makes the camera follow the x-position of the player
        _camera.transform.position = new Vector3(transform.position.x, 0, -10);

        if (!isSanityDraining)
        {
            StartCoroutine(SanityDrain());
        }

        if (_health <= 0 || _sanity <= 0 || transform.position.y < -5)
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
            _rb2D.velocity = Vector2.up * _jumpForce;
            AudioSource.PlayClipAtPoint(jumpSfx, transform.position);
            // _rb2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    public void TakeDamage()
    {
        if (!isInvincible)
        {
            Debug.Log("Damaged player!");
            _health--;
        }
    }
    
    public IEnumerator OnBecameInvisible()
    {
        isInvincible = true;
        _spriteRenderer.sprite = invincibleSprite;
        yield return new WaitForSeconds(5);
        isInvincible = false;
        _spriteRenderer.sprite = normalSprite;
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
        //StopCoroutine(OnBecameInvisible());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
