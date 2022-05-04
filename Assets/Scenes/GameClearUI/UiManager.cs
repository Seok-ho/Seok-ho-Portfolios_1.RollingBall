using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject ClearPanel;
    public GameObject NoPanel;

    public void GameClearNextBtn()
    {
        if (PlayerManager.stage == 1)
        {
            SceneManager.LoadScene(2);
            PlayerManager.stage++;
        }
        else if (PlayerManager.stage == 2)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void GameClearNoBtn()
    {
        NoPanel.SetActive(true);

    }


    public void NoPanel_YesBtn()
    {

    }
    public void NoPanel_NoBtn()
    {
        NoPanel.SetActive(false);
    }
}
