using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public static PlayerActions _actions;
    public static PlayerController _player;

    public static void BindNewPlayer(PlayerController player)
    {
        _player = player;
    }

    public static void Init(PlayerController player)
    {
        _actions = new PlayerActions();
        BindNewPlayer(player);

        _actions.Player.Move.performed += ctx => _player.Move(ctx.ReadValue<Vector2>());

    }

}
