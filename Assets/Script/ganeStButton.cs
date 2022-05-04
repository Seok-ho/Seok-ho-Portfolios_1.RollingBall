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

    //������ stage ���� �־������ν� Ŭ�����ϸ� ���� ���������� �̵��ϴ� ������ ���� 
    public void GameStart()
    {
        SceneManager.LoadScene(PlayerManager.stage);    
    }

    public void Go_NextStage()  //���� �ܰ�� �̵��Ͻðڽ��ϱ�? ��ư ������ �� 
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

    public void Go_NextStage_No() //���� �ܰ� �̵� ���Ҷ� 
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

    public void All_Clear() //stage3 ��Ŭ���� �Լ�
    {
        SceneManager.LoadScene(0); //����ȭ������ �̵�
        PlayerManager.stage = 1; //�ٽ� ������ �� �ְ� 1�� �ʱ�ȭ 
    }
}
