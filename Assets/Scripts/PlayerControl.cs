using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector2 _move;

    [SerializeField] private float _speed;

    void Awake()
    {
        Inputs.Init(this);
    }

    void Update()
    {
        transform.Translate(Vector2.right * (_speed * Time.deltaTime * _move.x), Space.Self);
    }

    public void Move(Vector2 direction)
    {
        _move = direction;
    }
}
