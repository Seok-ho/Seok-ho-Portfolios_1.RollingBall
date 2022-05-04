using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource gameSound;          //플레이어 소리 재생 
    public Rigidbody playPosition;  //플레이어 포지션 초기화 함수

    public PlayerManager playerm;
    public GameObject maincamera;
    public GameObject overcamera;
    public GameObject player;

    public GameObject UiPanel;
    public GameObject playerP;
    public GameObject gameoverP;
    public GameObject gameClear;
    public GameObject allClear; //stage3 올클리어 

    public Text PlayerHP;
    private void Awake()
    {
        int php = 3 - PlayerPrefs.GetInt("hp");
        PlayerHP.text = string.Format("{0:n0}", php);
    }
    private void Start()
    {
        //플레이어가 죽으면 소리 안나길래 넣어줌 
        gameSound = GetComponent<AudioSource>();
        gameSound.Play();
    }

    public void LateUpdate()
    {
        
            int php = 3 - playerm.hp;
            PlayerHP.text = string.Format("{0:n0}", php);
        
    }
    public void GameStart() //다시 하트뜨고 게임 시작하는거 
    {
        maincamera.SetActive(true);
        overcamera.SetActive(false);
        playerP.SetActive(true);
        gameoverP.SetActive(false);
        player.gameObject.SetActive(true);
        playerm.hp = 0;
        ResetGame();
    }
    public void GameOver()
    {
        maincamera.SetActive(false);    //메인 꺼짐 
        overcamera.SetActive(true);     //오버카메라 켜짐
        playerP.SetActive(false);       //Hp 하트 사라짐 
        gameoverP.SetActive(true);      //게임오버 화면 나옴 

        player.gameObject.SetActive(false); //플레이어 사라짐 

    }

    public void GameClear()
    {
        maincamera.SetActive(false);
        overcamera.SetActive(true);
        playerP.SetActive(false);
        gameClear.SetActive(true);

        player.gameObject.SetActive(false);
        //게임 클리어 화면 나오는거 true로 만들기 
    }

    public void AllClear()
    {
        maincamera.SetActive(false);
        overcamera.SetActive(true);
        playerP.SetActive(false);
        allClear.SetActive(true);

        player.gameObject.SetActive(false);
    }

    public void ResetGame() //플레이어 죽으면 해당 포지션에서 다시 시작 
    {
        playPosition.position = new Vector3(0, 1, 0);
    }
}
