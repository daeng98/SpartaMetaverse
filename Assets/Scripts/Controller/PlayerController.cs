using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    void OnMove(InputValue input)
    {
        movementDirection = input.Get<Vector2>();
        movementDirection = movementDirection.normalized;

        if (input.Equals(KeyCode.A) == true)
        {
            characterRenderer.flipX = true;
        }
        else if (input.Equals(KeyCode.D) == true)
        {
            characterRenderer.flipX = false;
        }
    }
    //void OnPress(InputValue input)
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //    {
    //        return;
    //    }
    //}
}
