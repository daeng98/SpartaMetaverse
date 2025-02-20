using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;

    void Start()
    {
        if(target == null) return;

        offsetX = transform.position.x - target.position.x;
        
    }

    void Update()           // 이전 강의 내용 그대로 사용, 미니게임 비행기 카메라 추적
    {
        if(target == null) return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
