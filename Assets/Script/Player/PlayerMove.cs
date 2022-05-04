using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float fallSpeed = -10f;
    public float jumpSpeed = 7f;



    /*public int hp = 0;
    AudioSource[] playerSound; // 플레이어와 관련된 음악 소스 가져옴  
    */
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(x, 0, y);
        velocity = velocity * speed;
        velocity.y = -fallSpeed;
        rigid.velocity = velocity;
    }

    /* private void OnTriggerEnter(Collider other) //프래팹Trap들 isTrigger킨 상태 
    { 
        Debug.Log("충돌감지");  //테스트 때문에 넣은거 
        playerSound[1].Play();  //충돌 일어나면 Player_Hurt 사운드 출력 
        if (other.tag == "Trap")
        {
            hp++;
            Debug.Log("충돌이 일어났습니다. 현재 HP: " + hp);
            if (hp >= 3) //3번이상 충돌이 일어나면
            {
                gamemanager.GameOver();

                GameRestart(); //게임 처음부터 다시 
            }
        }
        if (other.tag == "Gun_Reward") //총 보상 먹으면 이제부터 발사가능 (아직 구현 못함)
        {
            canFire = true;
        }
    } */
    /*void GameRestart() //이 부분만 수정하면 될듯 
    {
        SceneManager.LoadScene(0);
    } */


    /*IEnumerator GunFire()
    {
        다른 유니티 코드 참고해서 발사 가능하게 하기 
        박스도 트리거 걸리면 사라지게 수정 
    }*/
    /*void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y <= 0.7f)
            {
                rigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
        }
    }*/
}