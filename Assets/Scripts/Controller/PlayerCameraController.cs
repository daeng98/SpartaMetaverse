using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float Speed = 5.0f;

    private Vector3 offset;

    private Vector3 targetPos;

    private void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;
    }

    private void Update()       // 플레이어 카메라 추적
    {
        if (target == null) return;

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Speed * Time.deltaTime);
    }
}
