using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        if(animator == null )
        {
            Debug.LogError("Not Founded Animator");
        }

        if (rigid == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()           // 죽었을 때 결과창 띄어줌, 스페이스바 눌리면 isFlap = true
    {
        if (isDead)
        {
            if(deathCooldown <= 0)
            {
                UIManager.Instance.ChangeState(UIState.Result);
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()          // 이전 강의 내용 그대로 사용, Flap 될때 행동
    {
        if (isDead) return;

        Vector3 velocity = rigid.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap= false;
        }

        rigid.velocity = velocity;

        float angle = Mathf.Clamp((rigid.velocity.y * 10), -90, 90);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)          // 이전 강의 내용 그대로 사용, 1초 뒤 죽음
    {
        if (godMode) return;

        if (isDead) return;
        
        isDead  = true;
        deathCooldown = 1f;

        animator.SetInteger("isDie", 1);
    }
}
