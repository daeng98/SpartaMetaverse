using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public int numBgCount = 5;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for(int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)         // 이전 강의 내용 그대로 사용, 뒷 배경 생성
    {
        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();

        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
