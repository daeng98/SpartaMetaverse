using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerController : BaseController
{
    void OnMove(InputValue input)
    {
        movementDirection = input.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnPress(InputValue input)
    {
        Vector2 playerDirection = movementDirection != Vector2.zero ? movementDirection : lastDirection;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, 5f, 1 << (LayerMask.NameToLayer("MiniGame")));

        if (input.isPressed)
        {
            if (hit.collider != null && (hit.collider.gameObject.layer == LayerMask.NameToLayer("MiniGame")))
            {
                UIManager.Instance.ChangeState(UIState.How);
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
