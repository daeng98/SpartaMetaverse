using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigid;
    protected StatController stat;

    [SerializeField] protected SpriteRenderer characterRenderer;
    [SerializeField] protected Sprite LeftRight;
    [SerializeField] protected Sprite Up;
    [SerializeField] protected Sprite Down;

    public Vector2 lastDirection = Vector2.down;
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    private bool isFilpX = true;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        stat = GetComponent<StatController>();

        if (rigid == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }

        if (stat == null)
        {
            Debug.LogError("Not Founded StatController");
        }
    }

    protected virtual void FixedUpdate()        // FixedUpdate에서 이동 관련 사용
    {
        Rotate(movementDirection);
        Movement(movementDirection);
    }

    private void Movement(Vector2 direction)        // 플레이어 이동
    {
        if (direction != Vector2.zero)
        {
            lastDirection = direction;
        }

        direction = direction * stat.Speed;
        rigid.velocity = direction;
    }

    private void Rotate(Vector2 direction)      // 회전 및 그에 맞는 스프라이트 변경
    {
        if (direction == Vector2.zero)
        {
            direction = lastDirection;
        }

        bool filpX = direction.x > 0f;
        bool filpUp = direction.y > 0f;
        bool filpDown = direction.y < 0f;

        characterRenderer.sprite = LeftRight;

        if (filpX != isFilpX)
        {
            isFilpX = filpX;
            characterRenderer.flipX = isFilpX;
        }

        if (filpUp)
        {
            characterRenderer.sprite = Up;
        }

        if (filpDown)
        {
            characterRenderer.sprite = Down;
        }
    }
}
