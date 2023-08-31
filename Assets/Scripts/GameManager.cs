using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public static GameManager instance;

    public int level;
    public int kill;
    public int exp;
    public int coin;
    public int[] nextExp = {10, 30, 60, 100, 150, 210, 280, 360, 450, 600};

    void Awake(){
        instance = this;

    }

    public void GetExp() {
        exp++;

        if (exp == nextExp[level]){
            level++;
            exp = 0;

        }
    }

    
}
