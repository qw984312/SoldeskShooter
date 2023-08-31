using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f; 

    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    // 생성된 coin이 랜덤으로 한번 점프하고, 아래로 떨어지는 기능
    void Jump(){
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        float randomJumpForce = Random.Range(4f, 8f);
        Vector3 jumpVelocity = Vector3.up * randomJumpForce;
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 먹지 못한 coin데이터는 사라지게 (minY 위치를 지나면)
        if(transform.position.y < minY){
            Destroy(gameObject);
        }
    }
}
