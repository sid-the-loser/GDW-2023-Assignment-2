using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public static PlayerAction _actions;
    public static PlayerControl _player;

    public static void BindNewPlayer(PlayerControl player)
    {
        _player = player;
    }

    public static void Init(PlayerControl player)
    {
        _actions = new PlayerAction();
        BindNewPlayer(player);

        _actions.Player.Movement.performed += ctx => _player.Move(ctx.ReadValue<Vector2>());
        _actions.Player.Jump.performed += ctx => _player.Jump();

        //SetPlayerControls();
    }

    /*public static void InitTitleControls(TitleScreenLogic title)
    {
        _actions = new PlayerAction();
        _actions.UI.AnyButton.performed += ctx => title.ChangeScene();
    }*/ //failed attempt on making title screen compatible with new input system

    public static void SetPlayerControls()
    {
        _actions.Player.Enable();
        _actions.UI.Disable();
    }

    public static void SetUIControls()
    {
        _actions.Player.Disable();
        _actions.UI.Enable();
    }

}
