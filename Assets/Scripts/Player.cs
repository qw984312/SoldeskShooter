using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed; // player 움직임 속도
    
    // 캐릭터 가벽 충돌시 떨림 방지
    // boundaryX 와 boundaryY 변수는 플레이어가 움직일 수 있는 가로와 세로 경계를 나타냅니다
    public float boundaryX = 5f;
    public float boundaryY = 5f;

    public bool isLive = true;
    public GameObject GameOverCanvas;
    [SerializeField]
    private GameObject btn_crystal; // 총알 
    [SerializeField] 
    private Transform ShootTransform; 
    [SerializeField] 
    private float shootInterval = 0.05f; // 총을 쏠때 간격 설정 
    private float lastShootTime; //최근에 쏜 시간

    private int score = 0; // 플레이어의 점수

    [SerializeField]
    private GameObject god_15_fire; //차징 스킬
    [SerializeField] 
    private Transform firePointForm;
    [SerializeField] 
    private float chargeTime; //차징스킬 충전시간
    private bool isCharging; //차징스킬 충전 여부

    void Update()
    {   
         // 플레이어 이동
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, moveY, 0f);

        // 플레이어 위치 제한
		// 이동한 후에는 Mathf.Clamp 함수를 사용하여 플레이어의 위치를 제한
        float clampedX = Mathf.Clamp(transform.position.x, -boundaryX, boundaryX);
        float clampedY = Mathf.Clamp(transform.position.y, -boundaryY, boundaryY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        //space버튼을 누를때 차징 스킬이 발사됨
        if(Input.GetKey(KeyCode.Space) && chargeTime < 2){ //space키를 누르고 있을 경우
            isCharging = true;
            if(isCharging == true){
                chargeTime += Time.deltaTime;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){ //space키를 눌렀을때
            Shoot();             
        }
        else if(Input.GetKeyUp(KeyCode.Space) && chargeTime >= 2){ //space키를 눌렀다 땠을 때
            ReleaseCharge();
        }
    }

    //충돌 떨림없이 벽에 붙이는 기능
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Monster"){
            Debug.Log("Game Over");
            Destroy(gameObject);
            GameOverCanvas.SetActive(true);
            Stop();
        }  
        else if(collision.gameObject.tag =="Coin"){
            Debug.Log("Coin +1");
            GameManager.instance.coin++;
            Destroy(collision.gameObject);
        }
    }

    //총을 쏠때 일정한 간격으로 공격하기 위한 기능
    void Shoot(){
        // 현재시간 - 마지막에 쏜 시간 > 총을 쏠 때 간격
        if(Time.time - lastShootTime > shootInterval){
            Instantiate(btn_crystal, ShootTransform.position, Quaternion.identity); // 새로운 총알 생성
            lastShootTime = Time.time; // 마지막 쏜 시간으로 업데이트 
        }
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("현재 점수: " + score);
    }

    void ReleaseCharge(){
        Instantiate(god_15_fire, firePointForm.position, Quaternion.identity);
        isCharging = false;
        chargeTime = 0;
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }



}

