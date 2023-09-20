using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static Controls controls;


    public static void Init(Player myPlayer)
    {
        controls = new Controls();

        controls.Game.Movement.performed += ctx => 
        {
            myPlayer.setMovementDirection(ctx.ReadValue<Vector3>());
        
        };

        controls.Permanent.Enable();


    }

    public static void GameMode()
    {
        controls.Game.Enable();
        controls.UI.Disable();
    }

    public static void UIMode()
    {
        controls.Game.Disable();
        controls.UI.Enable();
    }

}