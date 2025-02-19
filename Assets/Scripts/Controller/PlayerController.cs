using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerController : BaseController
{
    public GameObject howUI;
    public LayerMask target;

    void OnMove(InputValue input)
    {
        movementDirection = input.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnPress(InputValue input)
    {
        int layermaskTarget = target;
        Vector2 playerDirection = movementDirection != Vector2.zero ? movementDirection : lastDirection;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, 5f, 1 << (LayerMask.NameToLayer("MiniGame")) | layermaskTarget);

        if (!howUI.activeSelf && input.isPressed)
        {
            if (hit.collider != null && (hit.collider.gameObject.layer == LayerMask.NameToLayer("MiniGame")))
            {
                if (howUI != null && !howUI.activeSelf)
                {
                    howUI.SetActive(true);
                }
            }
        }
        else
        {
            if (howUI != null && howUI.activeSelf)
            {
                howUI.SetActive(false);
            }
        }

        if (howUI != null && !howUI.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
