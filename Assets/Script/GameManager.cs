using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource gameSound;          //�÷��̾� �Ҹ� ��� 
    public Rigidbody playPosition;  //�÷��̾� ������ �ʱ�ȭ �Լ�

    public PlayerManager playerm;
    public GameObject maincamera;
    public GameObject overcamera;
    public GameObject player;

    public GameObject UiPanel;
    public GameObject playerP;
    public GameObject gameoverP;
    public GameObject gameClear;
    public GameObject allClear; //stage3 ��Ŭ���� 

    public Text PlayerHP;
    private void Awake()
    {
        int php = 3 - PlayerPrefs.GetInt("hp");
        PlayerHP.text = string.Format("{0:n0}", php);
    }
    private void Start()
    {
        //�÷��̾ ������ �Ҹ� �ȳ��淡 �־��� 
        gameSound = GetComponent<AudioSource>();
        gameSound.Play();
    }

    public void LateUpdate()
    {
        
            int php = 3 - playerm.hp;
            PlayerHP.text = string.Format("{0:n0}", php);
        
    }
    public void GameStart() //�ٽ� ��Ʈ�߰� ���� �����ϴ°� 
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
        maincamera.SetActive(false);    //���� ���� 
        overcamera.SetActive(true);     //����ī�޶� ����
        playerP.SetActive(false);       //Hp ��Ʈ ����� 
        gameoverP.SetActive(true);      //���ӿ��� ȭ�� ���� 

        player.gameObject.SetActive(false); //�÷��̾� ����� 

    }

    public void GameClear()
    {
        maincamera.SetActive(false);
        overcamera.SetActive(true);
        playerP.SetActive(false);
        gameClear.SetActive(true);

        player.gameObject.SetActive(false);
        //���� Ŭ���� ȭ�� �����°� true�� ����� 
    }

    public void AllClear()
    {
        maincamera.SetActive(false);
        overcamera.SetActive(true);
        playerP.SetActive(false);
        allClear.SetActive(true);

        player.gameObject.SetActive(false);
    }

    public void ResetGame() //�÷��̾� ������ �ش� �����ǿ��� �ٽ� ���� 
    {
        playPosition.position = new Vector3(0, 1, 0);
    }
}
