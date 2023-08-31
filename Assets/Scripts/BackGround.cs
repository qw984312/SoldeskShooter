using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed; // 배경이 움직이는 속도

    void Update()
    {
        Vector3 curPos = transform.position; // 배경의 현재 위치
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime; // 배경의 변화될 위치
        transform.position = curPos + nextPos;

    if (curPos.y < -10) // 배경을 재활용 하기 위해 현재 위치가 -10보다 작을 때
    {
        Vector3 newPos = new Vector3(transform.position.x, 10f, transform.position.z); // 새로운 위치 지정
        transform.position = newPos;
        }
    }
}
