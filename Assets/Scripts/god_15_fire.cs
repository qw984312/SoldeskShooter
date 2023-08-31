using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class god_15_fire : MonoBehaviour
{   
    [SerializeField]
    private float moveSpeed; //차징스킬 속도

    public float damage = 5f; //차징 스킬 데미지
    
    // Start is called before the first frame update
    void Start()
    {
        // 다 쏜 차징스킬 데이터가 점점 쌓이는 것을 막기위해서
        // 바깥으로 나가면 1초 뒤에 데이터 삭제 
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // 위 방향으로 지정한 속도로 차징스킬이 날아가는 기능 
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
