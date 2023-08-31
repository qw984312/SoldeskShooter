using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{   
    [SerializeField] 
    private float moveSpeed = 10f;

    private float minY = -7f; 

    [SerializeField]
    private float hp = 1f; // 몬스터 체력

    [SerializeField]
    private GameObject goldAmount; // 몬스터 처치 시 얻는 골드 양

    public void SetMoveSpeed(float moveSpeed){
        this.moveSpeed = moveSpeed;
    }

    void Update()
    {
        // 몬스터들은 화면 아래로 이동
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        // 몬스터들이 y축 -7 아래로 나가면 기존 몬스터데이터 삭제 
        if(transform.position.y < minY){
            Destroy(gameObject);
        }
    }

    // 충돌 감지
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "btn_crystal"){
            btn_crystal btn_crystal = other.gameObject.GetComponent<btn_crystal>();
            hp -= btn_crystal.damage;
            if(hp <= 0){        // 몬스터 체력이 0 이하인 경우
                // Debug.Log("몬스터 1마리 사망");
                Die();    // 몬스터 사망 메소드 호출
                // 몬스터가 사라지고 coin이 생성될때 위치
                Instantiate(goldAmount, transform.position, Quaternion.identity);
            }
            //충돌하자마자 총알이 사라짐
            Destroy(other.gameObject);
        }
    }

    private void Die()
    {
        // 플레이어에게 점수를 추가
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.IncreaseScore();
            GameManager.instance.kill++;
            GameManager.instance.GetExp();
        }

        // 몬스터를 제거
        Destroy(gameObject);
    }
}
