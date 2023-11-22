using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    //public static PlayerActions _actions;
    public static PlayerControl _player;

    public static void BindNewPlayer(PlayerControl player)
    {
        _player = player;
    }

    public static void Init(PlayerControl player)
    {
        //_actions = new PlayerActions();
        BindNewPlayer(player);

        //_actions.Player.Move.performed += ctx => _player.Move(ctx.ReadValue<Vector2>());

        PlayMode();
    }

    public static void PlayMode()
    {
        //_actions.Player.Enable();
        //_actions.UI.Disable();
    }

}
