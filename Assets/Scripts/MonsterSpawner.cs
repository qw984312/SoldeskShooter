using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] monsters; //몬스터들을 선언

    // 화면 윗의 다섯 위치를 배열로
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};

    [SerializeField]
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartMonsterRoutine();
    }

    void StartMonsterRoutine(){
        // StartCoroutine을 통해서 MonsterRoutine함수 안에 있는
        // 시간 지정(yield return new WaitForSeconds(3f))으로 
        // 바로 몬스터를 생성하지 않고 
        StartCoroutine("MonsterRoutine");
    }

    IEnumerator MonsterRoutine(){
        // 3초 후에 몬스터가 생성된다.
        yield return new WaitForSeconds(3f);

        int monsterIndex = 0;
        int spawnCount = 0;
        float moveSpeed = 5f;

        // 각각 위치에서 몬스터가 랜덤으로 계속 나오게 하기 위해서
        while (true) {    
            // 윗 화면의 지정된 위치에서 동시에 다섯마리씩 몬스터 등장  
            foreach (float posX in arrPosX) {    
                SpawnMonster(posX, monsterIndex, moveSpeed);
            }

            // 다섯마리 몬스터가 10번호 나왔을 때 
            // 그 다음 단계 이상의 몬스터들만 등장 
            spawnCount++;
            if(spawnCount % 10 == 0){ // 10, 20, 30, ...
                monsterIndex++;
                // 다음 단계로 갈때마다 속도 2 증가
                moveSpeed += 2;
            }

            // spawnInterval(1.5f초) 후 반복문을 실행 
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnMonster(float posX, int index, float moveSpeed){
        // 몬스터가 등장하는 위치
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        
        // 20% 확률로 다른 몬스터가 나오게
        if(Random.Range(0, 5) == 0){
            index++;
        }

        // 마지막 번호의 몬스터 다음은 없으므로 생성할때
        // 오류가 나서 방지 차원에   
        if(index >= monsters.Length){
            index = monsters.Length - 1;
        }

        // index : 몬스터 번호 
        GameObject monsterObject = Instantiate(monsters[index], spawnPos, Quaternion.identity);
        Monster monster = monsterObject.GetComponent<Monster>();
        monster.SetMoveSpeed(moveSpeed);
    }
}
