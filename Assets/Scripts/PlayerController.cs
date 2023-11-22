using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _move;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        _move = direction;
    }
}
