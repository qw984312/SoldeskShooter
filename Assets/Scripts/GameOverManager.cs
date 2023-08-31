using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // 게임 씬으로 전환
        Time.timeScale = 1;
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //play모드를 false로
#else
            Application.Quit(); // 게임 종료
#endif
    }

}
