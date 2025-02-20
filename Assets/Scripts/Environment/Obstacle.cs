using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float LowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    UIManager ui;

    public void Start()
    {
        ui = UIManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)          // 이전 강의 내용 그대로 사용, 장애물 생성
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(LowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }   

    public void OnTriggerExit2D(Collider2D collision)       // 이전 강의 내용 그대로 사용, 장애물 통과시 점수 증가
    {
        Player player = collision.GetComponent<Player>();

        if (player != null) 
        {
            ui.AddScore(1);
        }
    }
}
