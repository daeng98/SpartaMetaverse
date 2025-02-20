using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    [Range(1f, 20f)][SerializeField] private float speed = 3;

    public float Speed          // 플레이어 스탯 설정, 스피드 밖에 없긴함
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
}
