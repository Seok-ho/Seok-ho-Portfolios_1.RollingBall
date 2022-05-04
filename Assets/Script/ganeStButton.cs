using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ganeStButton : MonoBehaviour
{
    public void StartButton() {
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            SceneManager.LoadScene(3);
        }
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //변수에 stage 변수 넣어줌으로써 클리어하면 다음 스테이지로 이동하는 식으로 변경 
    public void GameStart()
    {
        SceneManager.LoadScene(PlayerManager.stage);    
    }

    public void Go_NextStage()  //다음 단계로 이동하시겠습니까? 버튼 눌렀을 때 
    {
        if (PlayerManager.stage == 1)
        {
            SceneManager.LoadScene(2);
            PlayerManager.stage = 2;
        }
        else if (PlayerManager.stage == 2)
        {
            SceneManager.LoadScene(3);
            PlayerManager.stage = 3;
        }
    }

    public void Go_NextStage_No() //다음 단계 이동 안할때 
    {
        if (PlayerManager.stage == 1)
        {
            PlayerManager.stage = 2;
            SceneManager.LoadScene(0);
        }
        else if (PlayerManager.stage == 2)
        {
            PlayerManager.stage = 3;
            SceneManager.LoadScene(0);
        }
    }

    public void All_Clear() //stage3 올클리어 함수
    {
        SceneManager.LoadScene(0); //메인화면으로 이동
        PlayerManager.stage = 1; //다시 시작할 수 있게 1로 초기화 
    }
}
