using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int hp = 0;
    public static int stage = 1;    //1단계부터 시작이니까 

    public AudioSource[] playerSound; // 플레이어와 관련된 음악 소스 가져옴 
    public GameManager gamemanager;
    Rigidbody rigid;
    Renderer myRenderer;

    Color hp1 = Color.yellow;
    Color hp2 = Color.red;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        playerSound = GetComponents<AudioSource>(); // 오디오 사운드 여러개니까 GetComponents 
        myRenderer = GetComponent<Renderer>(); //hp 색상 때문에 가져옴 
        Debug.Log("테스트 메세지");
        playerSound[0].Play();
    }
    private void Update()
    {
        if (playerSound[0] == false) playerSound[1].Play();
        Debug.Log("현재 HP:" + hp); //hp 밖으로 빼서하면 될거 같음 콜라이더에 안넣구

        if (transform.position.y <= -10 || Input.GetKeyDown(KeyCode.Escape))
        {
            gamemanager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other) //프래팹Trap들 isTrigger킨 상태 
    {
        Debug.Log("충돌감지");  //테스트 때문에 넣은거 
        playerSound[1].Play();  //충돌 일어나면 Player_Hurt 사운드 출력 
        if (other.tag == "Trap")
        {
            hp++;
            if (hp == 1) myRenderer.material.color = hp1;
            if (hp == 2) myRenderer.material.color = hp2;
            Debug.Log("충돌이 일어났습니다. 현재 HP: " + hp);
            if (hp >= 3) //3번이상 충돌이 일어나면
            {
                Debug.Log("HP가 3 아래입니다.:" + hp);
                gamemanager.GameOver();
                //GameRestart(); //게임 처음부터 다시 
                //Destroy_Player(); 추후에 수정 
                hp = 0;

            }
        }
        if (other.tag == "Goal_In") //골인 하는 보물 상자 먹었을 때 
        {
            Debug.Log("현재 stage = " + stage);
            if (stage == 3) gamemanager.AllClear();
            gamemanager.GameClear();
            // 완주 성공 창 띄우고 스테이지 넘어갈지 메인화면 나갈지 화면창 
        }
    }

    void GameRestart() //플레이어가 죽었을 때 실행 안쓰임 이거 
    {
        Debug.Log("게임오버 함수 실행");
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

    /*IEnumerator Destroy_Player()
{
    Debug.Log("destroy 함수가 실행됩니다.");
    Destroy(gameObject, 1f);
    yield return new WaitForSeconds(3f);
    GameRestart(); //게임 처음부터 다시 
}*/

}
